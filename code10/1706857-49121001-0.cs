    CheckBox cb = new CheckBox();
 ...
    int checkboxnumber = Myclass.suggestionline.Count();
            
            for (int i = 0; i < checkboxnumber; i++)
            {
                cb = new CheckBox();
                cb.Text = Myclass.suggestionline[i][0];
                cb.Location = new Point(5, 5 + i * 24);
                cb.BackColor = Color.White;
                cb.Name = "checkbox"+i;
                cb.AutoSize = true;
                cb.Checked = true;
                cb.CheckedChanged += new EventHandler(CheckedChanged);
                panel1.Controls.Add(cb);
            };
