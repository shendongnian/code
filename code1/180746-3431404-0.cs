    DispatcherTimer timer = new DispatcherTimer();
    timer.Tick += delegate
    {
        label.Content = counter.ToString();
        counter++;
    };
    timer.Interval = TimeSpan.FromMilliseconds(2000);
    timer.Start();
