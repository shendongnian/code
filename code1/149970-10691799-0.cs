    private DispatcherTimer updateTimer;
    
    private void initTimer
    {
         updateTimer = new DispatcherTimer(DispatcherPriority.SystemIdle); 
         updateTimer.Tick += new EventHandler(OnUpdateTimerTick);
         updateTimer.Interval = TimeSpan.FromMilliseconds(1000);
         updateTimer.Start();
    }
    
    private void OnUpdateTimerTick(object sender, EventArgs e)
    {
        lblTimer.Content = "hello";
    }
