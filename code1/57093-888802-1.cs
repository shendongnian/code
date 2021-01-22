    public static void CursorTest()
    {
      int testsize = 1000000;
      Console.WriteLine("Testing cursor position");
      Stopwatch sw = new Stopwatch();
      sw.Start();
      for (int i = 0; i < testsize; i++)
      {
        Console.Write("\rCounting: {0}     ", i);
      }
      sw.Stop();
      Console.WriteLine("\nTime using \\r: {0}", sw.ElapsedMilliseconds);
      sw.Reset();
      sw.Start();
      int top = Console.CursorTop;
      for (int i = 0; i < testsize; i++)
      {
        Console.SetCursorPosition(0, top);        
        Console.Write("Counting: {0}     ", i);
      }
      sw.Stop();
      Console.WriteLine("\nTime using CursorLeft: {0}", sw.ElapsedMilliseconds);
      sw.Reset();
      sw.Start();
      Console.Write("Counting:          ");
      for (int i = 0; i < testsize; i++)
      {        
        Console.Write("\b\b\b\b\b\b\b\b{0,8}", i);
      }
      sw.Stop();
      Console.WriteLine("\nTime using \\b: {0}", sw.ElapsedMilliseconds);
    }
