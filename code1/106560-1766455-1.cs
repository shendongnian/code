    public void CallerTest()
    {
        CallerInformation();
    }
    
    public void CallerInformation()
    {
        System.Diagnostics.StackTrace stackTrace = new System.Diagnostics.StackTrace();
        System.Diagnostics.StackFrame caller = stackTrace.GetFrame(1); // The caller
        int callLineNumber = caller.GetFileLineNumber();
        System.Reflection.MethodBase callerMethod = caller.GetMethod();
        string callerName = callerMethod.ReflectedType.FullName + "." + callerMethod.Name;
        System.Diagnostics.Debug.Write(string.Format("Caller - Line:{0} Method:{1}", callLineNumber, callerName));
    }
