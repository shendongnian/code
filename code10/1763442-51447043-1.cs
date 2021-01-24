	public static void Main()
	{
		Example test = new Example("value");
		test.Assign("newValue");
		Console.WriteLine(test.SomeProperty); // prints "newValue"
	}
