    foreach (char ch in test) {
        Label newlabel = new Label();
        newlabel.Location = new System.Drawing.Point(x + i, y);
        newlabel.Text = ch.ToString();
        newlabel.AutoSize = true; 
        panel1.Controls.Add(newlabel);
        i += 15;
    }
