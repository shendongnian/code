    static public void NoValue(object value) {}
	static public void Test(Expression<Action<char>> action) 
	{
		Console.WriteLine("Test()");
	}
	static public void Test<T>(Expression<Func<char, T>> func) 
	{
		Console.WriteLine("Test<T>()");
	}
