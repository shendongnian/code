    public void SaveChanges(string message,  
        [System.Runtime.CompilerServices.CallerMemberName] string callerMethod = "",  
        [System.Runtime.CompilerServices.CallerFilePath] string sourceFile = "",  
        [System.Runtime.CompilerServices.CallerLineNumber] int lineNumber = 0)  
    {
        try
        {
            db.SaveChanges();
        }  
        catch (...)
        {
             // here you can use callerMethod, sourceFile, lineNumber
             // as string in your diagnostic message
        }
    }  
