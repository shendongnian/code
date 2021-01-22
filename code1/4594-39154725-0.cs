    using System;
    using System.Diagnostics;
    
    internal class PressAnyKey
    {
      private static Thread inputThread;
      private static AutoResetEvent getInput;
      private static AutoResetEvent gotInput;
      private static CancellationTokenSource cancellationtoken;
      
      static PressAnyKey()
      {
        // Static Constructor called when WaitOne is called (technically Cancel too, but who cares)
        getInput = new AutoResetEvent(false);
        gotInput = new AutoResetEvent(false);
        inputThread = new Thread(ReaderThread);
        inputThread.IsBackground = true;
        inputThread.Name = "PressAnyKey";
        inputThread.Start();
      }
    
      private static void ReaderThread()
      {
        while (true)
        {
          // ReaderThread waits until PressAnyKey is called
          getInput.WaitOne();
          // Get here 
          // Inner loop used when a caller uses PressAnyKey
          while (!Console.KeyAvailable && !cancellationtoken.IsCancellationRequested)
          {
            Thread.Sleep(50);
          }
          // Release the thread that called PressAnyKey
          gotInput.Set();
        }
      }
    
      /// <summary>
      /// Signals the thread that called WaitOne should be allowed to continue
      /// </summary>
      public static void Cancel()
      {
        // Trigger the alternate ending condition to the inner loop in ReaderThread
        if(cancellationtoken== null) throw new InvalidOperationException("Must call WaitOne before Cancelling");
        cancellationtoken.Cancel();
      }
    
      /// <summary>
      /// Wait until a key is pressed or <see cref="Cancel"/> is called by another thread
      /// </summary>
      public static void WaitOne()
      {
        if(cancellationtoken==null || cancellationtoken.IsCancellationRequested) throw new InvalidOperationException("Must cancel a pending wait");
        cancellationtoken = new CancellationTokenSource();
        // Release the reader thread
        getInput.Set();
        // Calling thread will wait here indefiniately 
        // until a key is pressed, or Cancel is called
        gotInput.WaitOne();
      }    
    }
