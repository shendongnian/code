	public static void Main()
	{
		Console.WriteLine((MyFlags)1); // Foo
		Console.WriteLine((MyFlags)7); // Foo, Bar, Baz
		
		Console.WriteLine((int)(MyFlags.Foo | MyFlags.Bar)); // 3
	}
	
	[Flags]
	enum MyFlags 
	{
		Foo = 1,
		Bar = 2,
		Baz = 4
	}
