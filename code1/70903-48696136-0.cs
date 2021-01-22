	public static class IL<T> where T : struct
	{
        // generic 'U' enables alternate casting for 'Interlocked' methods below
		public delegate U _cmp_xchg<U>(ref U loc, U _new, U _old);
        // we're mostly interested in the 'T' cast of it
		public static readonly _cmp_xchg<T> CmpXchg;
		static IL()
		{
            // size to be atomically swapped; must be 4 or 8.
			int c = Marshal.SizeOf(typeof(T).IsEnum ?
									Enum.GetUnderlyingType(typeof(T)) :
									typeof(T));
			if (c != 4 && c != 8)
				throw new InvalidOperationException("Must be 32 or 64 bits");
			var dm = new DynamicMethod(
				"__IL_CmpXchg<" + typeof(T).FullName + ">",
				typeof(T),
				new[] { typeof(T).MakeByRefType(), typeof(T), typeof(T) },
				MethodInfo.GetCurrentMethod().Module,
				false);
			var il = dm.GetILGenerator();
			il.Emit(OpCodes.Ldarg_0);    // ref T loc
			il.Emit(OpCodes.Ldarg_1);    // T _new
			il.Emit(OpCodes.Ldarg_2);    // T _old
			il.Emit(OpCodes.Call, c == 4 ?
					((_cmp_xchg<int>)Interlocked.CompareExchange).Method :
					((_cmp_xchg<long>)Interlocked.CompareExchange).Method);
			il.Emit(OpCodes.Ret);
			CmpXchg = (_cmp_xchg<T>)dm.CreateDelegate(typeof(_cmp_xchg<T>));
		}
	};
