    [DebuggerStepThrough]
    internal void MyHelper(Action someCallback)
    {
        try
        {
            someCallback();
        }
        catch(Exception ex)
        {
            // Debugger will not break here
            // because of the DebuggerStepThrough attribute
            DoSomething(ex);
            throw;
        }
    }
