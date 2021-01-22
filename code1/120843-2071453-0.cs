    #define "Debug" 
    
    [ Conditional("Debug") ]
    public void TargetMethod()
    {
       Trace.WriteLine("Exiting DebugThis for " + _callingMethod);
    }
