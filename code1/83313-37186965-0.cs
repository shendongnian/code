	void Main()
	{
		var result = MyMethod();
		Console.WriteLine($"Result: {result.Property1}, {result.Property2}");
	}
	
	public dynamic MyMethod()
	{
		return new { Property1 = "test1", Property2 = "test2" };
	}
