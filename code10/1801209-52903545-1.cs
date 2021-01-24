    private Timer _triggerTimer;
    public TaskScheduler()
    {            
        _triggerTimer = new Timer(1000);
        _triggerTimer.Elapsed += (TriggerTimerTick);
    }
    
    public Dispose()
    {
       if(_triggerTimer != null){
           _triggerTimer.Dispose()
           _triggerTimer = null;
    }
