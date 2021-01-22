    public void CallerTest()
    {
        CallerInformation();
    }
    
    public void CallerInformation()
    {
        System.Diagnostics.StackTrace stackTrace = new System.Diagnostics.StackTrace();
        System.Diagnostics.StackFrame caller = stackTrace.GetFrame(1);
        int callLineNumber = caller.GetFileLineNumber();
        string callerName = caller.GetMethod().Name;
        System.Diagnostics.Debug.Write(string.Format("Caller - Line:{0} Method:{1}", callLineNumber, callerName));
    }
