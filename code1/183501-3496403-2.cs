    public static void Main(string[] args)
    {
        var timer = new System.Timers.Timer();
        timer.Interval = 1000;
        //timer.Elapsed += (s, a) => { Console.WriteLine(DateTime.Now); };
        timer.Elapsed += (s, a) => 
         { Console.WriteLine("{1} {0}", DateTime.Now, Thread.CurrentThread.ManagedThreadId); };
        timer.SynchronizingObject = new Synchronizer();
        timer.Start();
        Console.ReadLine();
    }
