    var trace = new System.Diagnostics.StackTrace(e.InnerException, true);
    if (trace.FrameCount > 0)
    {
        var frame = trace.GetFrame(trace.FrameCount - 1);
        var className = frame.GetMethod().ReflectedType.Name;
        var methodName = frame.GetMethod().ToString();
        var lineNumber = frame.GetFileLineNumber();
    }
