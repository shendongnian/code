	public static void Main()
	{
        Console.WriteLine(AddComma("a 1 b"));
		Console.WriteLine(AddComma("hello 1234 bye"));
		Console.WriteLine(AddComma("987 middle text 654"));
		Console.WriteLine(AddComma("1/2 is a number containing other characters"));
		Console.WriteLine(AddComma("this also 12-3 has numbers"));
	}
	
	public static string AddComma(string input)
	{
		return Regex.Replace(input, @"(\d+(-|/)?\d+)|\d+", m => $"{m.Value},");
	}
