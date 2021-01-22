    private static MethodBase GetCallingMethod()
    {
      return new StackFrame(2, false).GetMethod();
    }
    
    private static Type GetCallingType()
    {
      return new StackFrame(2, false).GetMethod().DeclaringType;
    }
