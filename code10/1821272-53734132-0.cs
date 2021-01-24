    static void Main(string[] args)
    {
       System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
       sw.Start();
       for (int i = 0; i < 10000000; i++)
       {
          Assert(i % 1000000 != 700, $"Oops on {i}");
       }
       Console.WriteLine("{0}", sw.Elapsed);
    }
    static void Assert(bool cond, string msg, params object[] args)
    {
       if (!cond)
          Console.WriteLine(msg, args);
    }
