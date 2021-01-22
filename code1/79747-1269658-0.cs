    instance.Log(() => GetDetailedDebugInfo());
    public void Log(Func<string> getMessage)
    {
        if (IsDebuggingEnabled) 
        {
            LogInternal(getMessage.Invoke());
        }
    }
