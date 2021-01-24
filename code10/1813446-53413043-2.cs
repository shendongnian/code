	public static void Main()
	{
		Console.WriteLine("1");
		
		Func<int> f = MakeFunc();
		f();
		
		Console.WriteLine("2");
