    public class RadioButton2 : RadioButton
	{
	   public string GroupName { get; set; }
	}
	private void RadioButton2_Clicked(object sender, EventArgs e)
	{
	    RadioButton2 rb = (sender as RadioButton2);
	    if (!rb.Checked)
	    {
		   foreach (var c in Controls)
		   {
		       if (c is RadioButton2 && (c as RadioButton2).GroupName == rb.GroupName)
		       {
			      (c as RadioButton2).Checked = false;
		       }
		   }
		   rb.Checked = true;
	    }
	}
	private void Form1_Load(object sender, EventArgs e)
	{
	    //a group
	    RadioButton2 rb1 = new RadioButton2();
	    rb1.Text = "radio1";
	    rb1.AutoSize = true;
	    rb1.AutoCheck = false;
	    rb1.Top = 50;
	    rb1.Left = 50;
	    rb1.GroupName = "a";
	    rb1.Click += RadioButton2_Clicked;
	    Controls.Add(rb1);
	    RadioButton2 rb2 = new RadioButton2();
	    rb2.Text = "radio2";
	    rb2.AutoSize = true;
	    rb2.AutoCheck = false;
	    rb2.Top = 50;
	    rb2.Left = 100;
	    rb2.GroupName = "a";
	    rb2.Click += RadioButton2_Clicked;
	    Controls.Add(rb2);
	    //b group
	    RadioButton2 rb3 = new RadioButton2();
	    rb3.Text = "radio3";
	    rb3.AutoSize = true;
	    rb3.AutoCheck = false;
	    rb3.Top = 80;
	    rb3.Left = 50;
	    rb3.GroupName = "b";
	    rb3.Click += RadioButton2_Clicked;
	    Controls.Add(rb3);
	    RadioButton2 rb4 = new RadioButton2();
	    rb4.Text = "radio4";
	    rb4.AutoSize = true;
	    rb4.AutoCheck = false;
	    rb4.Top = 80;
	    rb4.Left = 100;
	    rb4.GroupName = "b";
	    rb4.Click += RadioButton2_Clicked;
	    Controls.Add(rb4);
	}
