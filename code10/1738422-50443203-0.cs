    public void TraceMessage(string message,  
            [System.Runtime.CompilerServices.CallerMemberName] string memberName = "",  
            [System.Runtime.CompilerServices.CallerFilePath] string sourceFilePath = "",  
            [System.Runtime.CompilerServices.CallerLineNumber] int sourceLineNumber = 0)  
    {  
        System.Diagnostics.Trace.WriteLine("message: " + message);  
        System.Diagnostics.Trace.WriteLine("member name: " + memberName);  
        System.Diagnostics.Trace.WriteLine("source file path: " + sourceFilePath);  
        System.Diagnostics.Trace.WriteLine("source line number: " + sourceLineNumber);  
    }  
