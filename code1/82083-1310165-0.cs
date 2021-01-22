    To get callers:
    StackTrace trace = new StackTrace();
    int caller = 1;
    StackFrame frame = trace.GetFrame(caller);
    string callerName = frame.GetMethod().Name;
