	public static bool ContainsAnySubstring(string predifined, int length, string input)
	{
		var sections = predifined.Remove(predifined.Length - length + 1).Select((_,i) => predifined.Substring(i, length));
		return sections.Any(section => input.Contains(section));
	}
	public static void Main()
	{
		Console.WriteLine(ContainsAnySubstring("qwerty", 3, "azerty") == true);
		Console.WriteLine(ContainsAnySubstring("qwerty", 5, "azerty") == false);
	}
