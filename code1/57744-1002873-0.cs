    //...
    if (searchTerms.Count() > 1)
    {
    	List<string> remainingSearchTerms = new List<string>();
    	for (int x = 1; x < searchTerms.Count(); x++)
    		remainingSearchTerms.Add(searchTerms[x]);
    	List<SearchResult> matchingResults = new List<SearchResult>();
    
    	foreach (SearchResult result in allResults)
    		if (MatchSearchTerms(new string[] { result.Name, result.Number, result.id.ToString() }, remainingSearchTerms.ToArray()))
    			matchingResults.Add(result);
    
    	return matchingResults.OrderBy(x => x.Name).Take(MaxResults).ToList();
    }
    else
    	return allResults.OrderBy(x => x.Name).Take(MaxResults).ToList();
    //...
    
    private bool MatchSearchTerms(string[] searchFields, string[] searchTerms)
    {
    	bool match = true;
    	foreach (string searchTerm in searchTerms)
    	{
    		if (match)
    		{
    			bool fieldMatch = false;
    			foreach (string field in searchFields)
    			{
    				if (field.ToLower().Contains(searchTerm.ToLower()))
    				{
    					fieldMatch = true; //Only one field needs to match the term
    					break;
    				}
    			}
    			match = fieldMatch;
    		}
    		else
    			break;
    	}
    	return match;
    }
