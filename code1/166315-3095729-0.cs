    StackTrace stackTrace = new StackTrace();           // get call stack
    StackFrame[] stackFrames = stackTrace.GetFrames();  // get method calls (frames)
    
    StackFrame callingFrame = stackFrames[1];
    MethodInfo method = callingFrame.GetMethod();
    Console.Write(method.Name);
    Console.Write(method.DeclaringType.Name);
