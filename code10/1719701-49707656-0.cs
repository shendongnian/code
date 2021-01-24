    public void startTimer()
    {
        System.Timers.Timer aTimer = new System.Timers.Timer();
        aTimer.Elapsed += new ElapsedEventHandler(timer_Tick);
        aTimer.Interval = 900000; 
        aTimer.Enabled = true;
     }
