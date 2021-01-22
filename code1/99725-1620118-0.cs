    #define StopTime
    using System;
    using System.Diagnostics;
    
    class C
    {
      static void Main() {
        Random rg = new Random();
    #if StopTime
        Stopwatch stopTime = new Stopwatch();
    #else
        TimeSpan time = TimeSpan.Zero;
    #endif
        for(int i=0;i<1000000;++i) {
    #if StopTime
          stopTime.Start();
    #else
          DateTime start = DateTime.Now;
    #endif
          Convert.ToString(rg.Next(0, 99999999)).PadLeft(8, '0');
    #if StopTime
          stopTime.Stop();
    #else
          DateTime end = DateTime.Now;
          time += end - start;
    #endif
        }
    #if StopTime
        Console.WriteLine(stopTime.Elapsed);
    #else
        Console.WriteLine(time);
    #endif
      }
    }
