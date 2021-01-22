    public static class EnumEx
	{
		public static dynamic Value(this Enum e)
		{
			switch (e.GetTypeCode())
			{
			case TypeCode.Byte:
				{
					return (byte) (IConvertible) e;
				}
			case TypeCode.Int16:
				{
					return (short) (IConvertible) e;
				}
			case TypeCode.Int32:
				{
					return (int) (IConvertible) e;
				}
			case TypeCode.Int64:
				{
					return (long) (IConvertible) e;
				}
			case TypeCode.UInt16:
				{
					return (ushort) (IConvertible) e;
				}
			case TypeCode.UInt32:
				{
					return (uint) (IConvertible) e;
				}
			case TypeCode.UInt64:
				{
					return (ulong) (IConvertible) e;
				}
			case TypeCode.SByte:
				{
					return (sbyte) (IConvertible) e;
				}
			}
			return 0;
		}
