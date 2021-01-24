    _UpdateTimerClock = new DispatcherTimer();
    _UpdateTimerClock.Interval = new TimeSpan(0, 0, 6);
    _UpdateTimerClock.IsEnabled = true;
    _UpdateTimerClock.Tick += UpdateTimerClockElapsed;
    
    				
    public void UpdateTimerClockElapsed(object tag, EventArgs args)
    {
    	try
    	{
    		Messenger.Default.Send(new NotificationViewModelRefresh());
    	}
    	catch (Exception err)
    	{
    		BusinessLogger.Manage(err);
    	}
    }
    
