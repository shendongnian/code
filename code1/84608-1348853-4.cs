    public void DoSomething()
    {
        TraceCall();
        // Do Something
    }
    public void TraceCall()
    {
        if (!loggingEnabled) { return; }
        StackFrame stackFrame = new StackFrame(1);
        // Log...
    }
