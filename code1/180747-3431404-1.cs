    DispatcherTimer timer = new DispatcherTimer();
    timer.Tick += delegate
    {
        label.Content = counter.ToString();
        counter++;
        if (counter == 500)
        {
            timer.Stop();
        }
    };
    timer.Interval = TimeSpan.FromMilliseconds(2000);
    timer.Start();
