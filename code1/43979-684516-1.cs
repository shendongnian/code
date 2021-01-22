    using System;
    using System.Diagnostics;
    using System.Threading;
    // In the class or whever appropriate
    static AutoResetEvent autoEvent = new AutoResetEvent(false);
    void MyWorkerThread()
    {
      Stopwatch stopWatch = new Stopwatch();
      TimeSpan Second30 = new TimeSpan(0,0,30);
      TimeSpan SecondsZero = new TimeSpan(0);
      TimeSpan waitTime = Second30 - SecondsZero;
      TimeSpan interval;
   
      while(1)
      {
        // Wait for work method to signal.
        if(autoEvent.WaitOne(waitTime, false))
        {
            // Signalled time to quit
            return;
        }
        else
        {
            stopWatch.Start();
            // grab a lock
            // do the work
            // Whatever...
            stopwatch.stop();
            interval = stopwatch.Elapsed;
            if (interval < Seconds30)
            {
               waitTime = Seconds30 - interval;
            }
            else
            {
               waitTime = SecondsZero;
            }
         }
       }
     }
