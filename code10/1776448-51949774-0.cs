    DispatcherTimer timer = new DispatcherTimer();
    private void startTime(bool what)
    {
        if (what == false)
        {
            MessageBox.Show("Start");
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick -= setTime;
            timer.Tick += setTime;
            timer.Start();
        }
        if (what == true)
        {
            MessageBox.Show("Stop");
            timer.Stop();
        }
    }
