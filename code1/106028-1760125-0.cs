    public ExceptionTraceListener : TraceListener
    {
      public override void Write(string message)
      {
        // Do nothing
      }
      public override void Fail(string message)
      {
        Debugger.Break();  // or if you prefer, throw new Exception(...)
      }
      public override void Fail(string message, string detailMessage)
      {
        Debugger.Break();  // or if you prefer, throw new Exception(...)
      }
    }
