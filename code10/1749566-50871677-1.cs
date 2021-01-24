	public static unsafe int ViaStructPointer()
	{
		int total = 0;
		for (int i = 0; i < Program.count; i++)
		{
			total += (*(Mask32*)(&i)).Byte1;
		}
		return total;
	}
	public static int ViaUnsafeAs()
	{
		int total = 0;
		for (int i = 0; i < Program.count; i++)
		{
			total += (Unsafe.As<int, Mask32>(ref i)).Byte1;
		}
		return total;
	}   
