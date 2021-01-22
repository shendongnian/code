    public static class MyLocker
    {
     public static void WithinLock(this object syncLock, Action action)
     {
      Monitor.Enter(syncLock)
      try
      {
       action();
      }
      finally
      {
       Monitor.Exit(syncLock)
      }
     }
    }
