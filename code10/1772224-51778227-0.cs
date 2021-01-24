    string[] tokens = { "NUMBER", "EXPRESSION", "STRING", "INTEGER" };
    
    for (int i = 0; i < tokens.Length; i++)
    {
    	string input = tokens[i];
    
    	if (input.Substring(0, Math.Min(input.Length, 3)) == "NUM")
    	{
    		Console.WriteLine(input.Substring(3));
    	}
    	else if (input.Substring(0, Math.Min(input.Length, 4)) == "EXPR")
    	{
    		Console.WriteLine(input.Substring(4));
    	}
    	else if (input.Substring(0, Math.Min(input.Length, 6)) == "STRING")
    	{
    		Console.WriteLine(input.Substring(6));
    	}
    }
