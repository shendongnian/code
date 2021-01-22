    [Conditional("Logging")]
    public static void Log(string msg, string filename) { }
    [Conditional("Logging"), Conditional("VerboseLogging")]
    public static void VerboseLog(string msg, string filename) {
        Log(msg, filename); // just defers call to Log()
    }
