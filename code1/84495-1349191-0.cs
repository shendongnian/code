    public void DoSomething()
    {
        TraceCall("DoSomething");
    } 
    public void TraceCall(string methodName)
    {
        if (!tracingEnabled) { return; }
        // Log the call
    }
