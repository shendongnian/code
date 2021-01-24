    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    namespace UpDownLeftRight {
        public partial class Form1 : Form {
            public Form1() {
                InitializeComponent();
                this.Load += new System.EventHandler(this.Form1_Load);
            }
            public int[] winner = new int[2];
            public Button[,] tmpButton = new Button[10, 10];
            private void Form1_Load(object sender, EventArgs e) {
                Random r = new Random();
                int ButtonWidth = 48;
                int ButtonHeight = 48;
                int start_x = 0;
                int start_y = 0;
                winner = new int[] { r.Next(0, 10), r.Next(0, 10) };
                this.Size = new Size((ButtonWidth * 11), (ButtonHeight * 11));
                for (int i = 0; i < 10; i++) {
                    for (int j = 0; j < 10; j++) {
                        tmpButton[i, j] = new Button();
                        tmpButton[i, j].Left = start_x + (i * ButtonWidth);
                        tmpButton[i, j].Top = start_y + (j * ButtonHeight);
                        tmpButton[i, j].Width = ButtonWidth;
                        tmpButton[i, j].Height = ButtonHeight;
                        tmpButton[i, j].Font = new Font(FontFamily.GenericMonospace, 17);
                        tmpButton[i, j].Click += new EventHandler(BTN_Grid_Click);
                        this.Controls.Add(tmpButton[i, j]);
                    }
                }
            }
            public void BTN_Grid_Click(object o, EventArgs e) {
                int[] guess = new int[2];
                for (int i = 0; i != tmpButton.GetLength(1); i++) {
                    for (int j = 0; j != tmpButton.GetLength(0); j++) {
                        if (tmpButton[i, j] == o) {
                            guess = new int[] { i, j };
                        }
                    }
                }
                int xDist = guess[0] - winner[0];
                int yDist = guess[1] - winner[1];
                string possible = "˂˃˄˅";
                if (xDist > 0) { possible = possible.Replace("˃", ""); }
                if (xDist < 0) { possible = possible.Replace("˂", ""); }
                if (xDist == 0) { possible = possible.Replace("˂", ""); possible = possible.Replace("˃", ""); }
                if (yDist > 0) { possible = possible.Replace("˅", ""); }
                if (yDist < 0) { possible = possible.Replace("˄", ""); }
                if (yDist == 0) { possible = possible.Replace("˄", ""); possible = possible.Replace("˅", ""); }
                ((Button)o).Text = possible;
            }
        }
    }
