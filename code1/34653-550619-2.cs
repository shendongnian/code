	static void Main(string[] args)
	{
		var regex = new Regex(@"\=(?<Long>[0-9]+)\?|\+(?<Short>[0-9]+)\?");
		string test1 = ";1234567890123456?+1234567890123456789012345123=9876543?";
		string test2 = ";1234567890123456?+9876543?";
		ShowGroupMatches(regex, test1);
		ShowGroupMatches(regex, test2);
		Console.ReadLine();
	}
	private static void ShowGroupMatches(Regex regex, string testCase)
	{
		int i = 0;
		foreach (Group grp in regex.Match(testCase).Groups)
		{
			if (grp.Success && i != 0)
			{
				Console.WriteLine(regex.GroupNameFromNumber(i) + " : " + grp.Value);
			}
			i++;
		}
	}
