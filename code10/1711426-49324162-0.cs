    // Since you only need '*' wildcard functionality, separate the wildcard
    // into segments to match against the list items
    
    public IEnumerable<string> GetWildcardSegments(string wildcard)
    {
    	return wildcard.Split('*');
    }
    
    public List<string> FilterListWithWildcard(IEnumerable<string> list, string wildcard)
    {
    	List<string> result = new List<string>();
    	foreach(string listItem in list)
    	{
    		bool matchFailed = false;
    		foreach(string segment in GetWildcardSegments(wildcard))
    		{
    			if(!listItem.Contains(segment))
    			{
    				matchFailed = true;
    				break;
    			}
    		}
    		if(!matchFailed)
    		{
    			result.Add(listItem);
    		}
    	}
        return result;
    }
