    DateTime dt1 = DateTime.Now.Date;
    DateTime dt2 = Convert.ToDateTime(TextBox4.Text.Trim()).Date;
    if (dt1 >= dt2)
    {
        MessageBox.Show("Valid Date");
    }
    else
    {
        MessageBox.Show("Invalid Date... Please Give Correct Date....");
    }
