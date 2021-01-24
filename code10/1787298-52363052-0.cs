    int x = 10; int y = 10;
            for (int i = 1; i < 5; i++)
            {
                Button mybutton = new Button();
                mybutton.Location = new Point(x, y + 54);
                y += 54;
                mybutton.Height = 44;
                mybutton.Width = 231;
                mybutton.BackColor = Color.Gainsboro;
                mybutton.ForeColor = Color.Black;
                mybutton.Text = i + "MenuName".ToString();
                mybutton.Name = i + "MenuName".ToString();
                mybutton.AccessibleName = i.ToString();
                mybutton.Font = new Font("Georgia", 12);
                Controls.Add(mybutton);
                mybutton.Click += new EventHandler(mybutton_Click);
            }
