	public static ushort ToUInt16(int value)
	{
		if (value < 0 || value > 65535)
		{
			throw new OverflowException(Environment.GetResourceString("Overflow_UInt16"));
		}
		return (ushort)value;
	}
