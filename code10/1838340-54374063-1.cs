    public static void Log(string text)
    {
    var stackFrame = new StackFrame(1, true);
    var callerMethodName = stackFrame.GetMethod().Name;
    var callerCalssName = stackFrame.GetMethod().DeclaringType.Name;
    }
