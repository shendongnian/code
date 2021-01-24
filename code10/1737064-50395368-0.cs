	string input = "f20s30t";
	string pattern = @"(?<=[fts])(?=\d+[fts])";
	string[] substrings = Regex.Split(input, pattern);
	foreach (string match in substrings)
	{
		Console.WriteLine("{0}", match);
	}
