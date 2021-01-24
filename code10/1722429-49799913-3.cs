    void Main()
    {
    	string validText = "name: abc name: def name: ghi name: jkl";
    	string invalidText = "name: abc x name: def name: ghi name: jkl";
    	string validPattern = @"name:\s*([a-z]*)\s*";
    
    	if (!Validate(invalidText))
    	{
    		try
    		{
    			throw new Exception("invalid input");
    		}
    		catch (Exception exception)
    		{
    			Console.WriteLine($"Input '{invalidText}' produces: {exception.Message}");
    		}
    	}
    
    	MatchCollection ms = Regex.Matches(validText, validPattern);
    
    	Console.Write($"Input '{validText}' produces: ");
    	foreach (Match m in ms)
    	{
    		Console.Write(m.Groups[1].Value + ", ");
    	}
    }
    
    public static bool Validate(string input)
    {
    	var pairs = input.Split(' ');
    	return !pairs.Where((item, index) => index % 2 != 0).Any(item => item.EndsWith(":"));
    }
    
    // Input 'name: abc x name: def name: ghi name: jkl' produces: invalid input
    // Input 'name: abc name: def name: ghi name: jkl' produces: abc, def, ghi, jkl, 
