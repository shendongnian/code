    protected void but(object sender, EventArgs e)
    {
        if (Cal.SelectedDate != DateTime.MinValue)
        {
            Label7.Text = "here is your selected date" +  Cal.SelectedDate.ToLongDateString();
        }
        else
        {
            //Whatever you want to happen if no valid date
        }
    }
