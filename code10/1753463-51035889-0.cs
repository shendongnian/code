	public static void Method<T>(T input)
	{
		Console.WriteLine(typeof(T) + " : " + input);
	}
	public static void Main()
	{
		Method("Hello");
		Method(234);
		Method(new DateTime());
	}
