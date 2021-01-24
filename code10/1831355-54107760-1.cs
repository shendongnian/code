	bool test;
	Assign(out test);
	
	if (test)
	{
		Console.WriteLine("Test is true");
	}
	
	private static void Assign(out bool foo)
	{
		foo = true;
	}
