    try
    {
        throw new Exception();
    }
    catch (Exception ex)
    {
        //Get a StackTrace object for the exception
        StackTrace st = new StackTrace(ex, true);
        //Get the first stack frame
        StackFrame frame = st.GetFrame(0);
        //Get the file name
        string fileName = frame.GetFileName();
        //Get the method name
        string methodName = frame.GetMethod().Name;
        //Get the line number from the stack frame
        int line = frame.GetFileLineNumber();
        //Get the column number
        int col = frame.GetFileColumnNumber();
    }
