    string validText = "name: abc name: def name: ghi name: jkl";
    string invalidText = "name: abc x name: def name: ghi name: jkl";
    string validPattern = @"name:\s*([a-z]*)\s*";
    string invalidPattern = @"name:\s*([a-z]+\s[a-z]\s)\s*";
    
    if (Regex.IsMatch(invalidText, invalidPattern))
    {
    	try {
    		throw new Exception("Invalid input");
    	}
    	catch (Exception exception)
    	{
    		Console.WriteLine($"Input '{invalidPattern}' produces {exception.Message}");
    	}
    }
    
    MatchCollection ms = Regex.Matches(validText, validPattern);
    
    Console.Write($"Input '{validText}' produces: ");
    foreach (Match m in ms)
    {
    	Console.Write(m.Groups[1].Value + ", ");
    }
    // Input 'name:\s*([a-z]+\s[a-z]\s)\s*' produces Invalid input
    // Input 'name: abc name: def name: ghi name: jkl' produces: abc, def, ghi, jkl, 
