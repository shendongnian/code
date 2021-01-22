    static void ShowExceptionStackTrace(Exception ex)
    {
        var stackTrace = new StackTrace(ex, true);
        foreach (var frame in stackTrace.GetFrames())
            Console.WriteLine(frame.GetMethod().Name);
    }
