    public static class LogWrapper
    {
        public static void TraceVerbose(string traceMessage)
        {
            Trace.WriteLine("VERBOSE: " + traceMessage);
        }
        // ...and so on...
    }
