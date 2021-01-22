    public static class CustomDebug
    {
        [DebuggerHidden]
        public static void Assert(Boolean condition, Func<Exception> exceptionCreator) { ... }
    }
    ...
    // The following assert fails, and because of the attribute the exception is shown at this line
    // Isn't affecting the stack trace
    CustomDebug.Assert(false, () => new Exception()); 
