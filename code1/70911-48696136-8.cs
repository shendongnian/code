	public static class my_globals
	{
		[DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static T CmpXchg<T>(ref T loc, T _new, T _old) where T : struct => 
                                                     _IL<T>.CmpXchg(ref loc, _new, _old);
    }
