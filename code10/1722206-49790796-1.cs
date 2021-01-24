	string input = "name: john, profession: lumberjack";
    string pattern = @"[a-z]+:\s*([a-z]+),\s*[a-z]+:\s*([a-z]+)";
	string[] subMatches = Regex.Match(input, pattern).Groups
        .Cast<Group>().Skip(1).Select(x => x.Value).ToArray();
			
	foreach (string s in subMatches)
	{
		Console.WriteLine(s);
	}
