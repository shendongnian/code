    using System.Diagnostics
    public static void TestStopWatch()
    {
     StopWatch sw = new StopWatch();
     int temp = 0;
     int repetitions = 1000000;
     sw.Reset();
     for (int i=0; i<repetitions; i++)
      temp++;
    long time = sw.Peek();   
    Console.WriteLine("Time = " + time/10.0 + " milliseconds.");
    }
