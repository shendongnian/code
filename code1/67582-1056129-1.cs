    try
    {
        ...
    }
    catch(Exception ex)
    {
        System.Diagnostics.StackTrace stackTrace = new System.Diagnostics.StackTrace(ex);
        System.Diagnostics.StackFrame firstFrame = stackTrace.GetFrame[0];
        Console.WriteLine(firstFrame.GetFileLineNumber);
        ...
    }
