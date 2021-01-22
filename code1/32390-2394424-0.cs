    public MyUserControl()
    {
        _resizeTimer.Tick += _resizeTimer_Tick;
    }
    DispatcherTimer _resizeTimer = new DispatcherTimer { Interval = new TimeSpan(0, 0, 0, 0, 1500), IsEnabled = false };
    private void UserControl_SizeChanged(object sender, SizeChangedEventArgs e)
    {
        _resizeTimer.IsEnabled = true;
        _resizeTimer.Stop();
        _resizeTimer.Start();
    }
    int tickCount = 0;
    void _resizeTimer_Tick(object sender, EventArgs e)
    {
        _resizeTimer.IsEnabled = false;
        //you can get rid of this, it just helps you see that this event isn't getting fired all the time
        Console.WriteLine("TICK" + tickCount++);
        //Do important one-time resizing work here
        //...
    }
