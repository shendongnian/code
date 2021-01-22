    System.Threading.Timer _timer;
    public void Start30DayTimer()
    {
        TimeSpan span = new TimeSpan(30, 0, 0, 0);
        TimeSpan disablePeriodic = new TimeSpan(0, 0, 0, 0, -1);
        _timer = new System.Threading.Timer(timer_TimerCallback, null, 
            span, disablePeriodic);
    }
    public void timer_TimerCallback(object state)
    {
        // do whatever needs to be done after 30 days
        _timer.Dispose();
    }
