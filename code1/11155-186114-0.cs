      using System;
      using System.Threading;
        
      class TimerExample
      {
          static public void Tick(Object stateInfo)
          {
              Console.WriteLine("Tick: {0}", DateTime.Now.ToString("h:mm:ss"));
          }
        
          static void Main()
          {
              TimerCallback callback = new TimerCallback(Tick);
        
              Console.WriteLine("Creating timer: {0}\n", 
                                 DateTime.Now.ToString("h:mm:ss"));
        
              // create a one second timer tick
              Timer stateTimer = new Timer(callback, null, 0, 1000);
        
              // loop here forever
              for (; ; ) { }
          }
      }
