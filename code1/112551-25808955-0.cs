	public static class Util
	{
		static Util()
		{
			var dynamicMethod = new DynamicMethod("Memset", MethodAttributes.Public | MethodAttributes.Static, CallingConventions.Standard,
				null, new [] { typeof(IntPtr), typeof(byte), typeof(int) }, typeof(Util), true);
			var generator = dynamicMethod.GetILGenerator();
			generator.Emit(OpCodes.Ldarg_0);
			generator.Emit(OpCodes.Ldarg_1);
			generator.Emit(OpCodes.Ldarg_2);
			generator.Emit(OpCodes.Initblk);
			generator.Emit(OpCodes.Ret);
			MemsetDelegate = (Action<IntPtr, byte, int>)dynamicMethod.CreateDelegate(typeof(Action<IntPtr, byte, int>));
		}
		public static void Memset(byte[] array, byte what, int length)
		{
			var gcHandle = GCHandle.Alloc(array, GCHandleType.Pinned);
			MemsetDelegate(gcHandle.AddrOfPinnedObject(), what, length);
			gcHandle.Free();
		}
		public static void ForMemset(byte[] array, byte what, int length)
		{
			for(var i = 0; i < length; i++)
			{
				array[i] = what;
			}
		}
		private static Action<IntPtr, byte, int> MemsetDelegate;
	}
