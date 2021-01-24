    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    namespace Buttons
    {
        public partial class Form1 : Form
        {
            const int ROWS = 5;
            const int COLS = 20;
            public Form1()
            {
                InitializeComponent();
                this.Load += new System.EventHandler(this.Form1_Load);
            }
            public void Form1_Load(object sender, EventArgs e)
            {
                new MyButton(ROWS, COLS, this);
            }
        }
        public class MyButton : PictureBox
        {
            const int WIDTH = 50;
            const int HEIGHT = 50;
            const int SPACE = 5;
            const int BORDER = 20;
            public static List<List<MyButton>> buttons { get; set; }
            public static List<MyButton> buttonList { get; set; }
            public Form1 form1;
            public int row { get; set; }
            public int col { get; set; }
            public MyButton()
            {
            }
            public MyButton(int rows, int cols, Form1 form1)
            {
                int count = 1;
                buttons = new List<List<MyButton>>();
                buttonList = new List<MyButton>();
                this.form1 = form1;
                for(int row = 0; row < rows; row++)
                {
                    List<MyButton> newRow = new List<MyButton>();
                    buttons.Add(newRow);
                    for (int col = 0; col < cols; col++)
                    {
                        MyButton newButton = new MyButton();
                        newButton.Height = HEIGHT;
                        newButton.Width = WIDTH;
                        newButton.Top = row * (HEIGHT + SPACE) + BORDER;
                        newButton.Left = col * (WIDTH + SPACE) + BORDER;
                        newButton.row = row;
                        newButton.col = col;
                        newButton.BackColor = RGBScale.AverageColor(count++);
                        newRow.Add(newButton);
                        buttonList.Add(newButton);
                        newButton.Click += new System.EventHandler(Button_Click);
                        form1.Controls.Add(newButton);
                    }
                }
            }
            public void Button_Click(object sender, EventArgs e)
            {
                MyButton button = sender as MyButton;
                MessageBox.Show(string.Format("Pressed Button Row {0} Column {1}", button.row, button.col));
            }
        }
        public class RGBScale
        {
            //each row is defined as follows
            //low range, high range,   Ra,      Ga,      Ba,      Rb,      Gb,      Bb,
            public static List<List<int>> table = new List<List<int>>() {
                new List<int>() {0, 1, 165, 242, 243, 125, 200, 255},
                new List<int>() {1, 25, 0, 255, 0, 63, 82, 0},
                new List<int>() {25, 50, 63, 82, 0, 255, 143, 31},
                new List<int>() {50, 75, 255, 143, 31, 255, 0, 0},
                new List<int>() {75, 100, 255, 0, 0, 255, 0,0}
            };
            public static Color AverageColor(float index)
            {
                int red = 255;
                int blue = 255;
                int green = 255;
                foreach (List<int> row in table)
                {
                    if (index <= row[1])
                    {
                        double start = row[0];
                        double end = row[1];
                        double scale = (index - start) / (end - start);
                        red = (int)Math.Round(scale * (row[5] - row[2]) + row[2]);
                        green = (int)Math.Round(scale * (row[6] - row[3]) + row[3]);
                        blue = (int)Math.Round(scale * (row[7] - row[4]) + row[4]);
                        break;
                    }
                }
                return Color.FromArgb(red, green, blue);
            }
        }
    }
