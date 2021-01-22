    static private void Trace()
    {
         StackFrame CallStack = new StackFrame(1, true);
         Log.WriteLine(
           String.Format("At {0}:{1}",
             CallStack.GetFileName(),
             CallStack.GetFileLineNumber()));
    }
