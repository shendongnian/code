    static private Type ApplicationType => typeof(Application);
    static private Type ThreadContextType => ApplicationType.GetNestedType("ThreadContext", BindingFlags.NonPublic);
    static private object GetCurrentThreadContext()
    {
        var threadContextCurrentMethod = ThreadContextType.GetMethod("FromCurrent", BindingFlags.Static | BindingFlags.NonPublic);
        var threadContext = threadContextCurrentMethod.Invoke(null, new object[] { });
        return threadContext;
    }
