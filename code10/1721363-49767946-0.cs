    DispatcherTimer dispatcherTimer;
    DateTimeOffset startTime;
    DateTimeOffset lastTime;
    DateTimeOffset stopTime;
    int timesTicked = 1;
    int timesToTick = 10;
    
    public void DispatcherTimerSetup()
    {
        dispatcherTimer = new DispatcherTimer();
        dispatcherTimer.Tick += dispatcherTimer_Tick;
        dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
        //IsEnabled defaults to false
        TimerLog.Text += "dispatcherTimer.IsEnabled = " + dispatcherTimer.IsEnabled + "\n";
        startTime = DateTimeOffset.Now;
        lastTime = startTime;
        TimerLog.Text += "Calling dispatcherTimer.Start()\n";
        dispatcherTimer.Start();
        //IsEnabled should now be true after calling start
        TimerLog.Text += "dispatcherTimer.IsEnabled = " + dispatcherTimer.IsEnabled + "\n";
    }
    
    void dispatcherTimer_Tick(object sender, object e)
    {
        DateTimeOffset time = DateTimeOffset.Now;
        TimeSpan span = time - lastTime;
        lastTime = time;
        //Time since last tick should be very very close to Interval
        TimerLog.Text += timesTicked + "\t time since last tick: " + span.ToString() + "\n";
        timesTicked++;
        if (timesTicked > timesToTick)
        {
            stopTime = time;
            TimerLog.Text += "Calling dispatcherTimer.Stop()\n";
            dispatcherTimer.Stop();
            //IsEnabled should now be false after calling stop
            TimerLog.Text += "dispatcherTimer.IsEnabled = " + dispatcherTimer.IsEnabled + "\n";
            span = stopTime - startTime;
            TimerLog.Text += "Total Time Start-Stop: " + span.ToString() + "\n";
        }
    }
    private void Page_Loaded_1(object sender, RoutedEventArgs e)
    {
        DispatcherTimerSetup();
    }
