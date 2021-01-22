	[MethodImpl(MethodImplOptions.NoInlining)]
	public static ILog GetLogger()
	{
		Type t;
		try { t = new StackFrame(1, false).GetMethod().DeclaringType; }
		catch { t = typeof(UnknownObject); }
		return GetLogger(t);
	}
	private static class UnknownObject { }
