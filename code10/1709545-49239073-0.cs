    static System.Timers.Timer timer;
    static void Main(string[] args)
    {
        var periodTimeSpan = TimeSpan.FromSeconds(3600);
        timer = new System.Timers.Timer(periodTimeSpan.TotalSeconds);
        timer.Elapsed += Timer_Elapsed;
        timer.Start();
    }
    private static void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
    {
        //Do some stuff
        timer.Start();
    }
