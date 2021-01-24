    void Main()
    {
    	string properties = "foo||||bar[as|is]ak|yak[yet|another]ll";
        foreach (var t in SplitMetadataProperties(properties))
    	{
    	  Console.WriteLine(t);	
    	} 
    }
    
    private static IEnumerable<string> SplitMetadataProperties(string properties)
    {
    	foreach (Match m in Regex.Matches(properties, @"\[.+?\]"))
    	{
    		properties = properties.Replace(m.Value, "|" + m.Value + "|");
    	}
    
    	string pattern = @"(\[.+?\])|[^\|\s]+";
    
    	foreach (Match match in Regex.Matches(properties, pattern))
    	{
    		yield return match.Value;
    	}
    }
