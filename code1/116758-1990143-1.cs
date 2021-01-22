    System.Timers.Timer _timer = null;
    
    widget.Changed += delegate 
    {
    	if (_timer==null)
    	{
    		_timer = new Timer(5000);
    		_timer.AutoReset = false;
    		_timer.Elapsed += delegate 
    		{
    			Save();	
    		};
    		_timer.Start();
    	}
    	else
    	{
    		_timer.Stop();
    		_timer.Start();
    	}
    };
