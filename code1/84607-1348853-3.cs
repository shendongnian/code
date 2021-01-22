    public void DoSomething()
    {
        if (loggingEnabled)
        {
            TraceCall(MethodBase.GetCurrentMethod().Name);
        }
        // Do Something
    }
    public void TraceCall(string methodName)
    {
        if (!loggingEnabled) { return; }
        // Log...
    }
