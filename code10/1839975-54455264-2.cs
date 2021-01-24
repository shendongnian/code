    private TimeSpan timeElapsed = TimeSpan.Zero;
    private DateTime started = DateTime.MinValue;
    private void StartStop_Click(object sender, EventArgs e)
    {
        DispatcherTimer dt = new DispatcherTimer();
        if ((string)StartStop.Content == "START")
        {
            dt.Interval = new TimeSpan(0, 0, 1);
            dt.Tick += dtTicker;
            started = DateTime.Now;
            dt.Start();
        }
    }
    private void dtTicker(object sender, EventArgs e)
    {
        timeElapsed = timeElapsed.Add(DateTime.Now - started);
        lblTest.Content = (timeElapsed).ToString(@"hh\:mm\:ss");
    }
    // This is how you reset the timer in this version.
    private void ResetTimer()
    {
        timeElapsed = TimeSpan.Zero;
    }
