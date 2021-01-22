    public static void Main(string[] args)
    {
        var timer = new System.Timers.Timer();
        timer.Interval = 1000;
        timer.Elapsed += (s, a) => { Console.WriteLine(DateTime.Now); };
        timer.SynchronizingObject = new Synchronizer();
        timer.Start();
        Console.ReadLine();
    }
