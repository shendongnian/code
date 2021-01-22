	/// <summary>
	/// <see cref="Method(string[])"/>
	/// </summary>
	public static void Main()
	{
		Method("String1", "String2");
	}
	public static void Method(params string[] values)
	{
		foreach (string value in values)
		{
			Console.WriteLine(value);
		}
	}
