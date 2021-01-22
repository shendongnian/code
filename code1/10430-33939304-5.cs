    static void Log(object message)
    {
        // frame 1, true for source info
        StackFrame frame = new StackFrame(1, true);
        var method = frame.GetMethod();
        var fileName = frame.GetFileName();
        var lineNumber = frame.GetFileLineNumber();
     
        // we'll just use a simple Console write for now    
        Console.WriteLine("{0}({1}):{2} - {3}", fileName, lineNumber, method.Name, message);
    }
