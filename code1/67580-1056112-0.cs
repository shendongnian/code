    try
    {
        ...
        ...
    
    }
    catch(...)
    {
        StackFrame sf = new StackFrame(true);
    
        int lineNumber = sf.GetFileLineNumber();
        int colNumber = sf.GetFileColumnNumber();
        string fileName = sf.GetFileName();
        string methodName = sf.GetMethod().Name;
    }
