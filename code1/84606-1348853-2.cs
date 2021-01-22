    public void DoSomething()
    {
        TraceCall(MethodBase.GetCurrentMethod().Name);
        // Do Something
    }
    public void TraceCall(string methodName)
    {
        if (!loggingEnabled) { return; }
        // Log...
    }
    TraceCall(MethodBase.GetCurrentMethod().Name)
