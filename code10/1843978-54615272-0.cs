    private DispatcherTimer timer;
    private void SetTimer()
    {
        timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(2) };
        timer.Tick += OnTimerTick;
        timer.Start();
    }
    private void OnTimerTick(object sender, EventArgs e)
    {
        Image.Source = new BitmapImage(new Uri("path to image 3"));
        timer.Stop();
    }
