    [System.Runtime.CompilerServices.MethodImpl(
     System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
    public static Type GetCallerType()
    {
    	StackTrace st = new StackTrace(2);
    	StackFrame sf = st.GetFrame(0);
    	return sf.GetMethod().DeclaringType;
    }
