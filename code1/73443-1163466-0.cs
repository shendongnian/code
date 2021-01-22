      StackTrace stackTrace = new StackTrace();           // get call stack
      StackFrame[] stackFrames = stackTrace.GetFrames();  // get method calls (frames)
    
      // write call stack method names
      foreach (StackFrame stackFrame in stackFrames)
      {
        Console.WriteLine(stackFrame.GetMethod().Name);   // write method name
      }
