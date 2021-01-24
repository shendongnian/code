    private static AsyncLocal<string> AsyncLocal
        = new AsyncLocal<string>(ThreadContextChanged);
    private static void ThreadContextChanged(AsyncLocalValueChangedArgs<string> changedArgs)
    {
        if (changedArgs.ThreadContextChanged &&
            changedArgs.CurrentValue != null)
        {
            AsyncLocal.Value = null;
        }
    }
