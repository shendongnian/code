    private Timer _timer;
    private DateTime _lastRun = DateTime.Now;
    
    protected override void OnStart(string[] args)
    {
    	_timer = new Timer(60 * 1000);
    	_timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
    	//...
    }
    
    
    private void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
    {
    	if (_lastRun.Date < DateTime.Now.Date)
    	{
    		_timer.Stop();
    		//
    		// do cleanup stuff
    		//
    		_lastRun = DateTime.Now;
    		_timer.Start();
    	}
    }
