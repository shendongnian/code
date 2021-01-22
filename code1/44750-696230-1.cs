    StackTrace st = new StackTrace(new StackFrame(true));
    Console.WriteLine(" Stack trace for current level: {0}", st.ToString());
    StackFrame sf = st.GetFrame(0);
    Console.WriteLine(" File: {0}", sf.GetFileName());
    Console.WriteLine(" Method: {0}", sf.GetMethod().Name);
    Console.WriteLine(" Line Number: {0}", sf.GetFileLineNumber());
    Console.WriteLine(" Column Number: {0}", sf.GetFileColumnNumber());
