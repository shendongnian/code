    public class MyClassThatNeedsLogging
    {
      private static TraceSource ts = 
              new TraceSource(MethodBase.GetCurrentMethod().DeclaringType.Name);
      //Or, to get full name (including namespace)
      private static TraceSource ts2 = 
              new TraceSource(MethodBase.GetCurrentMethod().DeclaringType.FullName);
    
      private count;
    
      public MyClassThatNeedsLogging(int count)
      {
        this.count = count;
    
        ts.TraceEvent(TraceEventType.Information, 0, "Inside ctor.  count = {0}", count);
      }
    
      public int DoSomething()
      {
        if (this.count < 0)
        {
          ts.TraceEvent(TraceEventType.Verbose, 0, "Inside DoSomething.  count < 0");
          count = Math.Abs(count);
        }
    
        for (int i = 0; i < count; i++)
        {
          ts.TraceEvent(TraceEventType.Verbose, 0, "looping.  i = {0}", i);
        }
      }
    }
