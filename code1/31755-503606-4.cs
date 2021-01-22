    private Timer _timer;
    private DateTime _lastRun = DateTime.Now.AddDays(-1);
    
    protected override void OnStart(string[] args)
    {
    	_timer = new Timer(10 * 60 * 1000); // every 10 minutes
    	_timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
        _timer.Start();
    	//...
    }
    
    
    private void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
    {
    	// ignore the time, just compare the date
    	if (_lastRun.Date < DateTime.Now.Date)
    	{
    		// stop the timer while we are running the cleanup task
    		_timer.Stop();
    		//
    		// do cleanup stuff
    		//
    		_lastRun = DateTime.Now;
    		_timer.Start();
    	}
    }
