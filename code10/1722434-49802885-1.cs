	string s = "name: abc x name: def name: ghi name: jkl";
	string pattern = @"\Gname:\s*([a-z]+)\s*";
	
	int endOfLastMatch = 0;
	
    // by using the \G anchor we can manage pattern repetition in a for-loop
	for (Match m = Regex.Match(s, pattern); m.Success; m = m.NextMatch())
	{
		Console.WriteLine(m.Groups[1].Value+ ", ");
        // keep track of until where matches were successful
		endOfLastMatch = m.Index + m.Length;
	}
	
	// in case that the match has failed, report where it has happened
	if (endOfLastMatch != s.Length) 
	{
		int reportSize = Math.Min(s.Length-endOfLastMatch, 10);
		string remainder = s.Substring(endOfLastMatch, reportSize);
		Console.WriteLine("Error: RegEx match failed at index "
            +endOfLastMatch+" (\""+remainder+"...\")");
	}
