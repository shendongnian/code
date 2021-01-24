    public void timer1_Tick(object sender, EventArgs e)
    {
        TimeSpan currentTime = DateTime.Now.TimeOfDay;
        if (currentTime >= DateTime.Parse("6:40 AM").TimeOfDay &&
            currentTime <= DateTime.Parse("7:25 AM").TimeOfDay)
        {
            label5.Text = "0";
        }
        else if (currentTime >= TimeSpan.Parse("07:30") &&
                 currentTime <= TimeSpan.Parse("08:15"))
        {
            label5.Text = "1";
        }
        else if (currentTime >= TimeSpan.Parse("08:20") &&
                 currentTime <= TimeSpan.Parse("09:05"))
        {
            label5.Text = "2";
        }
        else
        {
            label5.Text = "nothing";
        }
    }
