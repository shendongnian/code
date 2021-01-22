    [Conditional("Debug")]
    public void LogMethodName()
    {
        Trace.WriteLine("Entering:" + new StackTrace().GetFrame(1).GetMethod().Name);
    }
