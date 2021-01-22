    private static int  iterations = 5;
    static void Main()
    {
      DoTimer(1000, iterations, (s, e) => { Console.WriteLine("testing..."); });
      Console.ReadLine();
    }
    
    static void DoTimer(double interval, int iterations, ElapsedEventHandler handler)
    {
      var timer = new System.Timers.Timer(interval);
      timer.Elapsed += handler;
      timer.Elapsed += (s, e) => { if (--iterations <= 0) timer.Stop(); };
      timer.Start();
    }
