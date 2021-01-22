    StackTrace stackTrace = new StackTrace();           
    StackFrame[] stackFrames = stackTrace.GetFrames();  
    foreach (StackFrame stackFrame in stackFrames)
        Console.WriteLine(stackFrame.GetMethod().Name);   
  
