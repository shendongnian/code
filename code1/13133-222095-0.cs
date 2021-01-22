    // assumes callers know where they're located at in the current stack trace.
    private Boolean IsExternallyCalled(int methodDepth)
    {
        System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace();
        
        System.Type callingType = trace.GetFrame(methodDepth).GetMethod().ReflectedType;
        System.Reflection.Assembly a = System.Reflection.Assembly.GetAssembly(callingType);
    
        return !(a.Equals(System.Reflection.Assembly.GetCallingAssembly()));
    }
