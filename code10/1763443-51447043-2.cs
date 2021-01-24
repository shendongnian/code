	public static void Main()
	{
		Example test = new Example("value");
		Example.Replace(ref test, "newValue");
		Console.WriteLine(test.SomeProperty); // prints "newValue"
	}
