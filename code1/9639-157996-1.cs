    System.Diagnostics.StackTrace callStack = new System.Diagnostics.StackTrace();
    System.Diagnostics.StackFrame frame = null;
    System.Reflection.MethodBase calledMethod = null;
    System.Reflection.ParameterInfo [] passedParams = null;
    for (int x = 0; x < callStack.FrameCount; x++)
    {
    	frame = callStack.GetFrame(x);
    	calledMethod = frame.GetMethod();
    	passedParams = calledMethod.GetParameters();
    	foreach (System.Reflection.ParameterInfo param in passedParams)
    		System.Console.WriteLine(param.ToString()); 
    }
