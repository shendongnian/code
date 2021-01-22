    static class ThreadEntryPoints
    {
      public static Main()
      {
        ShowDialog();
      }
    
      public static Other_Main()
      {
        // ... do some work ...
        _event.Set();
      }
    
      private static ShowDialog()
      {
        // ... do some work ...
        _event.WaitOne(/* optionally set timeout */);
      }
    
      private static readonly ManualResetEvent _event = new ManualResetEvent(false);
    }
