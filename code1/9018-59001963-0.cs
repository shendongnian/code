    private static void Main(string[] args)
    {
       int threadCount = 0;
       try
       {
          for (int i = 0; i < int.MaxValue; i ++)
          {
             new Thread(() => Thread.Sleep(Timeout.Infinite)).Start();
             threadCount ++;
          }
       }
       catch
       {
          Console.WriteLine(threadCount);
          Console.ReadKey(true);
       }
    }
