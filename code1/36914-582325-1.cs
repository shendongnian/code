    public static string[] splitItems(string inp)
    {
    	if(inp.Length == 0)
    		return new string[0];
    	else
    		return inp.Split(',');
    }
