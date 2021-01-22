	public static class IL<T1, T2>
	{
		public delegate long _ref_offs(ref T1 hi, ref T2 lo);
		public static readonly _ref_offs RefOffs;
		static IL()
		{
			var dm = new DynamicMethod(
				Guid.NewGuid().ToString(),
				typeof(long),
				new[] { typeof(T1).MakeByRefType(), typeof(T2).MakeByRefType() },
				typeof(Object),
				true);
			var il = dm.GetILGenerator();
			il.Emit(OpCodes.Ldarg_0);
			il.Emit(OpCodes.Ldarg_1);
			il.Emit(OpCodes.Sub);
			il.Emit(OpCodes.Conv_I8);
			il.Emit(OpCodes.Ret);
			RefOffs = (_ref_offs)dm.CreateDelegate(typeof(_ref_offs));
		}
	};
