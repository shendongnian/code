    static void Main()
    {
      DoTimer(1000, 5, (s, e) => { Console.WriteLine("testing..."); });
      Console.ReadLine();
    }
    
    static void DoTimer(double interval, int iterations, ElapsedEventHandler handler)
    {
      var timer = new System.Timers.Timer(interval);
      timer.Elapsed += handler;
      timer.Elapsed += (s, e) => { if (--interations <= 0) timer.Stop(); };
      timer.Start();
    }
