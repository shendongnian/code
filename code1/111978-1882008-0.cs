    public static IEnumerable<Match> GetMatches(Regex regex, string input)
    {
    	var m = regex.Match(input);
    	while (m.Success)
    	{
    		yield return m;
    
    		m = m.NextMatch();
    	}
    }
