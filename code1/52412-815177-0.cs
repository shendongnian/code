    timer.Interval = TimeSpan.FromSeconds(5).TotalMilliseconds;
    timer.Elapsed = Timer_OnElapsed;
    timer.AutReset = false;
    timer.Start();
    
    
    public void Timer_OnElapsed(object sender, ElapsedEventArgs e)
    {
        if (!found)
        {
          found = LookForItWhichMightTakeALongTime();
        }
        timer.Start();
    }
