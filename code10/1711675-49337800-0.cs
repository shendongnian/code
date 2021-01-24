    using System.Windows.Threading;
    ...
    var t = new DispatcherTimer();
    t.Interval = TimeSpan.FromSeconds(15);
    t.Tick += timer_Tick;
    t.Start();
    void timer_Tick(object sender, EventArgs e)
    {
    }
