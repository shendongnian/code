    public static void DoTrace(string message)
    {
        DoTrace(message,true);
    }
    
    public static void DoTrace(string message, bool includeDate)
    {
        if (includeDate) {
            Trace.WriteLine(DateTime.Now + ": " + message);
        } else {
            Trace.WriteLine(message);
        }
    }
