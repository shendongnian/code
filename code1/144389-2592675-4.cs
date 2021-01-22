    public string Test(string query, string input, char[] ignorelist)
    {
    	string ignorePattern = "[";
    	for (int i=0; i<ignoreList.Length; i++)
    	{
    		if (ignoreList[i] == '-')
    		{
    			ignorePattern.Insert(1, "-");
    		}
    		else
    		{
    			ignorePattern += ignoreList[i];
    		}
    	}
    	ignorePattern += "]*";
    	
    	for (int i = 0; i < query.Length; i++)
    	{
    		pattern += query[0] + ignorepattern;
    	}
    	
    	Regex r = new Regex(pattern);
    	Match m = r.Match(input);
    	return m.IsSuccess ? m.Value : string.Empty;
    }
