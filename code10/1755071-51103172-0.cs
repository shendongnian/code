    public void CreateTimer() 
    {
       var timer = new System.Timers.Timer(1000); // fire every 1 second
       timer.Elapsed += HandleTimerElapsed;
    }
    public void HandleTimerElapsed(object sender, ElapsedEventArgs e)
    {
        Application.Current.Dispatcher.Invoke(
        () => 
        {
             //do things on UI thread...
             SwitchTheTabs();
        }
    );    
    
