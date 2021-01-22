    [DebuggerStepThrough]
    static void DebuggerStepThroughInPartialClass()
    {
            WrappedClass.NonDebuggerStepThrough();
    }
    
    class WrappedClass{
       static void NonDebuggerStepThroughInNewClass()
       {
            int bar = 0;
            bar++;
       }
    }
