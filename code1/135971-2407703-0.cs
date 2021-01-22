    DateTime start = Convert.ToDateTime(TextBox1.Text);
    DateTime end = Convert.ToDateTime(TextBox2.Text);
    DateTime now = DateTime.Now;
    if (now >= start.Date && mow <= end.Date)
    {
       lblResult.Text = "true";
    }
    else
    {
       lblResult.Text = "false";
    }
