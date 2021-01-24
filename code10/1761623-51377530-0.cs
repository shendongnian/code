    public static void Main(string[] args)
    {
        DispatcherTimer timer = new DispatcherTimer();
        timer.Interval = TimeSpan.FromMilliseconds(5000);;
        timer.IsEnabled = true;
        timer.Tick += OnTimerTick;
    }
    
    private void OnTimerTick(object sender, EventArgs e)
    {
        var thread = new Thread(new ThreadStart(()=>yourMethodToCall()));
        thread.Start();
    }
