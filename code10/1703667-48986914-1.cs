    bool handled = false;
    private void timer1_Tick(object sender, EventArgs e)
    {
        var d1 = DateTime.Now;
        var d2 = dateTimePicker1.Value;
        if (d1.Year == d2.Year && d1.Month == d2.Month && d1.Day == d2.Day &&
            d1.Hour == d2.Hour && d1.Minute == d2.Minute)
        {
            if (!handled) //Allow running once
            {
                handled = true;
                DoSomething();
            }
        }
    }
