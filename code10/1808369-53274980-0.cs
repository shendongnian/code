    while (dr13.Read())
    {
    String ss = (dr13["ans"]).ToString();
    Console.WriteLine(ss);
    String comme = (dr13["comment"]).ToString();
    Console.WriteLine(comme);
    String fridd = (dr13["frid"]).ToString();
    
    GroupBox gb = new GroupBox();
    gb.Width = 700;
    gb.Height = 50;
    
    RadioButton rb = new RadioButton();
    rb.Width = 130;
    rb.Text = "Satisfactory";
    rb.ForeColor = Color.White;
    rb.Name = fridd;
    if (ss == "Satisfactory")
    {
         rb.Checked = true;
    }
    RadioButton rb1 = new RadioButton();
    rb1.Text = "Not satisfactory";
    rb1.Width = 130;
    rb1.ForeColor = Color.White;
    rb1.Name = fridd;
    if (ss == "Not satisfactory")
    {
        rb1.Checked = true;
    }
    RadioButton rb2 = new RadioButton();
    rb2.Text = "Need improvement";
    rb2.Width = 160;
    rb2.ForeColor = Color.White;
    rb2.Name = fridd;
    if (ss == "Need improvement")
    {
       rb2.Checked = true;
    }
    RadioButton rb3 = new RadioButton();
    rb3.Text = "NA";
    rb3.Width = 130;
    rb3.ForeColor = Color.White;
    rb.Name = fridd;
    if (ss == "NA")
    {
        rb3.Checked = true;
    }
    gb.Controls.Add(rb);
    gb.Controls.Add(rb1);
    gb.Controls.Add(rb2);
    gb.Controls.Add(rb3);
    this.Controls.Add(gb);
    flowLayoutPanel1.Controls.Add(gb);
    }
