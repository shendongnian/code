    ...
    
    void LongRunningMethod(object monitorSync)
    {
       //do stuff    
       lock (monitorSync) {
         Monitor.Pulse(monitorSync);
       }
    }
    void ImpatientMethod() {
      Action<object> longMethod = LongRunningMethod;
      object monitorSync = new object();
      bool timedOut;
      lock (monitorSync) {
        longMethod.BeginInvoke(monitorSync, null, null);
        timedOut = !Monitor.Wait(monitorSync, TimeSpan.FromSeconds(30)); // waiting 30 secs
      }
      if (timedOut) {
        // it timed out.
      }
    }
       ...
