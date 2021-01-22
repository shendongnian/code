    using System.Threading;
    static EventWaitHandle _startedEvent;
    static void main()
    {  
      _startedEvent = new EventWaitHandle(false, EventResetMode.ManualReset, @"Global\ConServerStarted");
      DoLongRunnningInitialization();
    
      // Signal the event so that all the waiting clients can proceed
      _startedEvent.Set();
    }
