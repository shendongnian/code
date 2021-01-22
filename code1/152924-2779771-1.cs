    public static class DebugEx
    {
        [Conditional("DEBUG")]
        public static void WriteLine(string format, params object[] args)
        {
            Debug.WriteLine(string.Format(format, args));
        }
    }
