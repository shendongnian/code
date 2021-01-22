    //The interface
    interface ITimerProcess {
      TimeSpan Period {get;}
      void PerformAction(string someInfo);
    }
    
    //A process
    class SayHelloProcess : ITimerProcess {
    
      public TimeSpan Period { get { return TimeSpan.FromHours(1); } }
    
      public void PerformAction(string someInfo) {
        Console.WriteLine("Hello, {0}!", someInfo);
      }
    }
