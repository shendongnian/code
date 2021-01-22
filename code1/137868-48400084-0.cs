    public static string KeyByValue(Dictionary<string, string> dict, string val)
    {
        string key = null;
        foreach (KeyValuePair<string, string> pair in dict)
    	{
            if (pair.Value == val)
            { 
    			key = pair.Key; 
    			break; 
    		}
    	}
    	return key;
    }
