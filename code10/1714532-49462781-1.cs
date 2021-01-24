    DispatcherTimer _timer = new DispatcherTimer();
    
    void DoWorkTimer()
    {
        _timer.Interval = TimeSpan.FromMilliseconds(200);
        _timer.Tick += _timer_Tick;
        _timer.IsEnabled = true;
    }
    
    void _timer_Tick(object sender, EventArgs e)
    {
        // do the work in the loop
    }
