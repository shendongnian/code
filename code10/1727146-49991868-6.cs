	public static bool GetBit(this short This, int bitNumber)
	{
		return (This & (1 << bitNumber)) != 0;
	}
	for (int i=0; i<8; i++)
	{
		Console.WriteLine(input.GetBit(i));
	}
