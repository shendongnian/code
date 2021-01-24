    DispatcherTimer timer = new DispatcherTimer();
    timer .Tick += dispatcherTimer_Tick;
    timer .Interval = new TimeSpan(0,0,1);
    timer .Start();
    private void dispatcherTimer_Tick(object sender, EventArgs e)
    {
     // Put some code here
    }
