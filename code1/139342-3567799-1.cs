    public static class TraceSourceExtensions
    {
      public static void TraceVerbose(this TraceSource ts, string message)
      {
        ts.TraceEvent(TraceEventType.Verbose, 0, message);
      }
    }
