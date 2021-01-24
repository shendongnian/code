    private string AddSpacesIfNecessary(string word)
    {
    	string[] prefixes = new string[] { "DAS", "DIE", "DER" }; // Add other prefixes
    	foreach(string prefix in prefixes)
    	{
    		if(word.StartsWith(prefix))
    		{
    			return word.Insert(prefix.Length - 1, " ");
    		}
    	}
    	// Prefixes are not found, no need to add spaces
    	return word;
    }
