    Panel panel=null;
    foreach(Image i in images)
    {
        panel =new Panel();
        panel.BackgroundImage=i;
        panel.TabStop=true;
        tableLayoutPanel1.Controls.Add(panel);
    }
    panel.Focus();
