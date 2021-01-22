                        else if (arLabel[i].Text == "")
                        {
                            this.arLabel[i].ForeColor = System.Drawing.Color.Red;
                            arLabel[i].Text = "o";
                            break;
                        }
                    }
                
            }
            temp = 0;
            help = 1;
            f3();
            
            
        }
        private void f1()
        {
            this.arLabel = new Label[9];
            int b = 400;
            int c = 40;
            for (int i = 0; i < arLabel.Length; i++)
            {
                if (i == 3 || i == 6)
                {
                    c = c + 200;
                    b =400;
                }
                this.arLabel[i] = new Label();
                this.arLabel[i].Location = new System.Drawing.Point(b, c);
                this.arLabel[i].Size = new System.Drawing.Size(200, 200);
                this.arLabel[i].TabIndex = i;
                this.arLabel[i].BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                this.arLabel[i].Text = "".ToString();
               arLabel[i].Click += new System.EventHandler(this.arLabel_Click);
                this.Controls.Add(arLabel[i]);
                this.arLabel[i].Font = new System.Drawing.Font("Modern No. 20", 120.74999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.arLabel[i].ForeColor = System.Drawing.Color.Green;
                arLabel[i].Visible = true;
                this.arLabel[i].BackColor = System.Drawing.Color.Khaki;
                this.arLabel[i].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                b = b + 200;
            }
        }
        private void f3()
        {
            if (arLabel[0].Text == arLabel[1].Text && arLabel[2].Text == arLabel[1].Text && arLabel[1].Text != "".ToString())
            {
                temp = 0;
                f2();
            }
            if (arLabel[3].Text == arLabel[4].Text && arLabel[3].Text == arLabel[5].Text && arLabel[3].Text != "".ToString())
            {
                temp = 0;
                f2();
            }
            if (arLabel[6].Text == arLabel[7].Text && arLabel[8].Text == arLabel[6].Text && arLabel[6].Text != "".ToString())
            {
                temp = 0;
                f2();
            }
            // if (arLabel[0].Text == arLabel[3].Text && arLabel[0].Text == arLabel[6].Text && arLabel[6].Text != "".ToString())
            // f2();
            if (arLabel[0].Text == arLabel[3].Text && arLabel[0].Text == arLabel[6].Text && arLabel[6].Text != "".ToString())
            {
                f2();
                temp = 0;
            }
            if (arLabel[1].Text == arLabel[4].Text && arLabel[4].Text == arLabel[7].Text && arLabel[7].Text != "".ToString())
            {
                temp = 0;
                f2();
            }
            if (arLabel[2].Text == arLabel[5].Text && arLabel[8].Text == arLabel[2].Text && arLabel[2].Text != "".ToString())
            {
                temp = 0;
                f2();
            }
            if (arLabel[0].Text == arLabel[4].Text && arLabel[4].Text == arLabel[8].Text && arLabel[8].Text != "".ToString())
            {
                temp = 0;
                f2();
            }
            if (arLabel[2].Text == arLabel[4].Text && arLabel[6].Text == arLabel[4].Text && arLabel[4].Text != "".ToString())
            {
                temp = 0;
                f2();
            }
        }
        private void f2()
        {
            if (help == 1)
            {
                r++;
               // label4.Text = r.ToString();
                MessageBox.Show("THE is o");
                f6();
            }
            else
            {
                b++;
              //  label5.Text = b.ToString();
                MessageBox.Show("THE is x");
            }
            for (int i = 0; i < arLabel.Length; i++)
                arLabel[i].Text = "".ToString();
            f6();
        }
        private void f6()
        {
            Random number = new Random();
            a = number.Next(0, 8);
            this.arLabel[a].ForeColor = System.Drawing.Color.Green;
            arLabel[a].Text = "o".ToString();
            s.PlaySync();
        }
    }
}
