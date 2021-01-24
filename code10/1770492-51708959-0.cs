    public async Task DoStuff()
    {
        DispatcherTimer timer = new DispatcherTimer();
        timer.Interval = new TimeSpan(0, 0, seconds);
        timer.Tick += Timer_Tick;
        timer.Start();
            
        await YourTask();
        timer.Stop();
        this.Cursor = Cursors.Default;            
    }
    private void Timer_Tick(object sender, EventArgs e)
    {
        this.Cursor = Cursors.Wait;
    }
