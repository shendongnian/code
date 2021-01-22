	static void Main(string[] args)
	{
		long l = long.MaxValue;
		
		Console.WriteLine(l);
		
		byte b = (byte) l;
		Console.WriteLine(b);
		
		b = Convert.ToByte(l);
	
		Console.WriteLine(b);
	}
