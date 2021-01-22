    System.Timers.Timer timer = new Timer();
    void Init()
    {
        timer.Elapsed += timer_Elapsed;
        int wait = 5 - (DateTime.Now.Second % 5);
        timer.Interval = wait*1000;
        timer.Start();
    }
    void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
    {
        timer.Stop();
        int wait = DateTime.Now.Second % 5;
        timer.Interval = wait * 1000;
        timer.Start();
    }
