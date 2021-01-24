	public static string ExtractVersionNumber(string input)
	{
		Match match = (new Regex(@"(?:\d+\.?){1,3}(?<=.)\d+")).Match(input);
	    if (match.Success)
	    {
	        return match.Value;
	    }
		return null;
	}
	
	void Main()
	{
		Console.WriteLine(ExtractVersionNumber("firefox-10.0.2.source.tar.bz2"));
	}
	
	
