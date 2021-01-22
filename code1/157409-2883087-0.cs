    public static class MyLocker
    {
     public static void WithinLock(this object syncLock, Action action)
     {
      Monitor.Enter(obj)
      try
      {
       action();
      }
      finally
      {
       Monitor.Exit(obj)
      }
     }
    }
