	void Main()
	{
		string text = "I was here on {D}/{MMM}/{YYYY}.";
		string result = Regex.Replace(text, "{[a-zA-Z]+}", ReplaceMatched);
		
		Console.WriteLine(result);
	}
	
	private string ReplaceMatched(Match match)
	{
		if( match.Success )
		{
			switch( match.Value )
			{
				case "{D}":
					return DateTime.Now.Day.ToString();
				case "{YYYY}":
					return DateTime.Now.Year.ToString();
				default:
					break;
			}
		}
		// note, early return for matched items.
		
		Console.WriteLine("Warning: Unrecognized token: '" + match.Value + "'");
		return match.Value;
	}
