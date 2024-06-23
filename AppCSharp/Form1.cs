using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Security;
namespace AppCSharp
{
    public partial class Form1 : Form
    {
        private int x = 12, y = 12;
        private Button[,] buttons  =new Button[3,3];
        private int player = 0; // 0 - игрок 1 (X), 1 - игрок 2 (O)

        private bool gameOver = false;

        public Form1()
        {
            InitializeComponent();
            this.Height = 700;
            this.Width = 900;
            player = 1;
            label1.Text = "Текущий ход: Игрок 1";
            for (int i = 0; i < buttons.Length / 3; i++)
            {
                for (int j = 0; j < buttons.Length / 3; j++)
                {
                    buttons[i, j] = new Button();
                    buttons[i, j].Size = new Size(200, 200);
                }
            }
            setButtons();         
           
        }
        
        private void setButtons()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j <3; j++)
                {
                    buttons[i, j].Location = new Point(12 + 206 * j, 12 + 206 * i);
                    buttons[i, j].Click += button1_Click;
                    buttons[i, j].Font = new Font(new FontFamily("Microsoft Sans Serif"), 138);
                    buttons[i, j].Text = "";
                    this.Controls.Add(buttons[i, j]);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!gameOver)
            {
                Button clickedButton = (Button)sender;
                if (clickedButton.Text == "")
                {
                    clickedButton.Text = (player == 0) ? "X" : "O";
                    CheckWin();
                    player = (player == 0) ? 1 : 0; // Переключение игрока
                    label1.Text = $"Делает шаг: Игрок {player + 1}";
                }
            }
        }

        private void CheckWin()
        {
            string winner = "";

         
            for (int row = 0; row < 3; row++)
            {
                if (buttons[row, 0].Text == buttons[row, 1].Text && buttons[row, 1].Text == buttons[row, 2].Text)
                {
                    if (!string.IsNullOrEmpty(buttons[row, 0].Text))
                    {
                        winner = buttons[row, 0].Text; 
                        break;
                    }
                }
            }

            
            for (int col = 0; col < 3; col++)
            {
                if (buttons[0, col].Text == buttons[1, col].Text && buttons[1, col].Text == buttons[2, col].Text)
                {
                    if (!string.IsNullOrEmpty(buttons[0, col].Text))
                    {
                        winner = buttons[0, col].Text;
                        break;
                    }
                }
            }

            if (buttons[0, 0].Text == buttons[1, 1].Text && buttons[1, 1].Text == buttons[2, 2].Text)
            {
                if (!string.IsNullOrEmpty(buttons[0, 0].Text))
                {
                    winner = buttons[0, 0].Text;
                }
            }
            else if (buttons[2, 0].Text == buttons[1, 1].Text && buttons[1, 1].Text == buttons[0, 2].Text)
            {
                if (!string.IsNullOrEmpty(buttons[2, 0].Text))
                {
                    winner = buttons[2, 0].Text; 
                }
            }

            bool isDraw = true;
            foreach (var button in buttons)
            {
                if (string.IsNullOrEmpty(button.Text))
                {
                    isDraw = false;
                    break;
                }
            }

            if (!string.IsNullOrEmpty(winner))
            {
                MessageBox.Show($"Победитель: {winner}!");
                gameOver = true;
                
            }
            else if (isDraw)
            {
                MessageBox.Show("Ничья! Игра завершена.");
                gameOver = true;
              
            }
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            this.Visible = false;
            form2.ShowDialog();
            this.Close();

        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    buttons[i, j].Text = "";
                    buttons[i, j].Enabled = true;
                }
            }
        }
        
    }
}
