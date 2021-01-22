    static void MethodA() { }
    static void MethodB() { }
    static void MethodC() { throw new Exception(); }
    static void Main(string[] args)
    {
        try
        {
            MethodA();
            MethodB();
            MethodC();
        }
        catch (Exception e)
        {
            System.Diagnostics.StackTrace callStack = new System.Diagnostics.StackTrace(e);
            System.Diagnostics.StackFrame frame = null;
            System.Reflection.MethodBase calledMethod = null;
            System.Reflection.ParameterInfo[] passedParams = null;
            for (int x = 0; x < callStack.FrameCount; x++)
            {
                callStack.GetFrame(x);
                calledMethod = frame.GetMethod();
                passedParams = calledMethod.GetParameters();
                foreach (System.Reflection.ParameterInfo param in passedParams)
                    System.Console.WriteLine(param.ToString());
            }
        }
    }
