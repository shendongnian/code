    public void DoWithRetry(Action action, TimeSpan sleepPeriod, int retryCount = 3)
    {
        while(true) {
          try {
            action();
            break; // success!
          } catch {
            if(--retryCount == 0) throw;
            else Thread.Sleep(sleepPeriod);
          }
       }
    }
