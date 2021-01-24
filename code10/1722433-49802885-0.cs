	string s = "name: abc x name: def name: ghi name: jkl";
	string pattern = @"\Gname:\s*([a-z]+)\s*";
	
	int endOfLastMatch = 0;
	
	for (Match m = Regex.Match(s, pattern); m.Success; m = m.NextMatch())
	{
		Console.Write(m.Groups[1].Value+ ", ");
		endOfLastMatch = m.Index + m.Length;
	}
	
	Console.WriteLine();
	
	// in case the match has failed, report where it has happened
	if (endOfLastMatch != s.Length) 
	{
		int reportSize = Math.Min(s.Length-endOfLastMatch, 10);
		string remainder = s.Substring(endOfLastMatch, reportSize);
		Console.WriteLine("Error: RegEx match failed at index "
            +endOfLastMatch+" (\""+remainder+"...\")");
	}
