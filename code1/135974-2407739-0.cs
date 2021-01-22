    DateTime start = Convert.ToDateTime(TextBox1.Text).Date;
    DateTime now = DateTime.Now.Date;
    DateTime end = Convert.ToDateTime(TextBox2.Text).Date;
    if (now >= start && now <= end)
    {
       lblResult.Text = "true";
    }
    else
    {
       lblResult.Text = "false";
    }
