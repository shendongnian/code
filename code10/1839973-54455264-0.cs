    private DateTime started = DateTime.MinValue;
    private void StartStop_Click(object sender, EventArgs e)
    {
        DispatcherTimer dt = new DispatcherTimer();
        if ((string)StartStop.Content == "START")
        {
            dt.Interval = new TimeSpan(0, 0, 1);
            dt.Tick += dtTicker;
            started = DateTime.Now
            dt.Start();
        }
    }
    private void dtTicker(object sender, EventArgs e)
    {
        lblTest.Content = (DateTime.Now - started).ToString(@"hh\:mm\:ss");
    }
