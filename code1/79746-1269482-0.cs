    // no need for a lambda
    instance.Log(GetDetailedDebugInfo)
    // Using these instance methods on the logger
    public void Log(Func<string> detailsProvider)
    {
        if (!DebuggingEnabled)
            return;
        this.LogImpl(detailsProvider());
    }
    public void Log(string message)
    {
        if (!DebuggingEnabled)
            return;
        this.LogImpl(message);
    }
    protected virtual void LogImpl(string message)
    {
        ....
    }
