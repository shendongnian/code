    public static class DebugHelper
    {
        [DebuggerHidden]
        [Conditional("DEBUG")]
        public static void Stop()
        {
           if (Debugger.IsAttached)
                Debugger.Break();
        }
    }
