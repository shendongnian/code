    System.Timers.Timer timer = new System.Timer(500);
    timer.Elapsed += new System.Timers.ElapsedEventHandler (MyTimerHandler);
    timer.Start();
    
    private void TimerHandler(object sender, System.Timers.ElapsedEventArgs e)
    {
        // optional - stop the timer to prevent overlapping events
        timer.Stop();
        // this is where you do your thing
        timer.Start();
    }
