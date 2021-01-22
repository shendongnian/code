    public unsafe class ConvertArrayType
	{
		[StructLayout(LayoutKind.Explicit)]
		private struct Union
		{
			[FieldOffset(0)] public sbyte[] sbytes;
			[FieldOffset(0)] public double[] doubles;
		}
		private Union _union; 
		public double[] doubles {
			get { return _union.doubles; }
		}
		public sbyte[] sbytes
		{
			get { return _union.sbytes; }
		}
		[StructLayout(LayoutKind.Sequential, Pack = 1)]
		private struct ArrayHeader
		{
			public UIntPtr type;
			public UIntPtr length;
		}
		private readonly UIntPtr SBYTE_ARRAY_TYPE;
		private readonly UIntPtr DOUBLE_ARRAY_TYPE;
		public ConvertArrayType(Array ary, Type newType)
		{
			fixed (void* pBytes = new sbyte[1])
			fixed (void* pDoubles = new double[1])
			{
				SBYTE_ARRAY_TYPE = getHeader(pBytes)->type;
				DOUBLE_ARRAY_TYPE = getHeader(pDoubles)->type;
			}
			Type typAry = ary.GetType();
			if (typAry == newType)
				throw new Exception("No Type change specified");
			if (!(typAry == typeof(SByte[]) || typAry == typeof(double[])))
				throw new Exception("Type Not supported");
			if (newType == typeof(Double[]))
			{
				ConvertToArrayDbl((SByte[])ary);
			}
			else if (newType == typeof(SByte[]))
			{
				ConvertToArraySByte((Double[])ary);
			}
			else
			{
				throw new Exception("Type Not supported");
			}
		}
		private void ConvertToArraySByte(double[] ary)
		{
			_union = new Union { doubles = ary };
			toArySByte(_union.doubles);
		}
		private void ConvertToArrayDbl(sbyte[] ary)
		{
			_union = new Union { sbytes = ary };
			toAryDouble(_union.sbytes);
		}
		private ArrayHeader* getHeader(void* pBytes)
		{
			return (ArrayHeader*)pBytes - 1;
		}
		private void toAryDouble(sbyte[] ary)
		{
			fixed (void* pArray = ary)
			{
				var pHeader = getHeader(pArray);
				pHeader->type = DOUBLE_ARRAY_TYPE;
				pHeader->length = (UIntPtr)(ary.Length / sizeof(double));
			}
		}
		private void toArySByte(double[] ary)
		{
			fixed (void* pArray = ary)
			{
				var pHeader = getHeader(pArray);
				pHeader->type = SBYTE_ARRAY_TYPE;
				pHeader->length = (UIntPtr)(ary.Length * sizeof(double));
			}
		}
	} // ConvertArrayType{}
