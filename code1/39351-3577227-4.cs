	public static class FastArraySerializer
	{
		[StructLayout(LayoutKind.Explicit)]
		private struct Union
		{
			[FieldOffset(0)] public byte[] bytes;
			[FieldOffset(0)] public float[] floats;
		}
		private static readonly int BYTE_ARRAY;
		private static readonly int FLOAT_ARRAY;
		private static readonly int PTR_SIZE = sizeof(UIntPtr);
		static unsafe FastArraySerializer()
		{
			var sampleByteArray = new byte[1];
			var sampleFloatArray = new float[1];
			
			fixed(byte* pBytes = sampleByteArray)
			fixed(float* pFloats = sampleFloatArray)
			{
				BYTE_ARRAY = *(UIntPtr*)(pBytes - 2*PTR_SIZE)
				FLOAT_ARRAY = *(UIntPtr*)(((byte*) pFloats) - 2*PTR_SIZE);
			}
		}
		public static void AsByteArray(this float[] floats, Action<byte[]> action)
		{
			if(floats == null)
			{
				action(null);
				return;
			}
			if(floats.Length == 0)
			{
				action(new byte[0]);
				return;
			}
			var union = new Union {floats = floats};
			union.floats.ToByteArray();
			try
			{
				action(union.bytes);
			}
			finally
			{
				union.bytes.ToFloatArray();
			}
		}
		
		public static void AsFloatArray(this byte[] bytes, Action<byte[]> action)
		{
			if(bytes == null)
			{
				action(null);
				return;
			}
			if(bytes.Length == 0)
			{
				action(new float[0]);
				return;
			}
			var union = new Union {bytes = bytes};
			union.bytes.ToFloatArray();
			try
			{
				action(union.floats);
			}
			finally
			{
				union.floats.ToByteArray();
			}
		}
		private static unsafe toFloatArray(this byte[] bytes)
		{
			fixed(byte* pBytes = bytes)
			{
				var pSize = (UIntPtr*)(pBytes - PTR_SIZE);
				var pArrayType = (UIntPtr*)(pBytes - 2*PTR_SIZE);
				*pSize = (UIntPtr)(bytes.Length - 2*PTR_SIZE);
				*pArrayType = FLOAT_ARRAY;
			}
		}
		
		private static unsafe toByteArray(this float[] bytes)
		{
			fixed(float* pFloats = floats)
			{
				var pBytes = (byte*) pFloats;
				
				var pSize = (UIntPtr*)(pBytes - PTR_SIZE);
				var pArrayType = (UIntPtr*)(pBytes - 2*PTR_SIZE);
				*pSize = (UIntPtr)(floats.Length*sizeof(float));
				*pArrayType = BYTE_ARRAY;
			}
		}
	}
