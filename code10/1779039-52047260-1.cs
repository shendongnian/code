    using System.Windows.Threading;
    ...
    DispatcherTimer timer = new DispatcherTimer();
    timer.Tick += TimerTick;
    timer.Interval = TimeSpan.FromSeconds(1);
    timer.Start();
    ...
    private void TimerTick(object sender, EventArgs e)
    {
        // Put some code here
    }
