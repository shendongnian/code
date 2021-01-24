    public static IEnumerable<string> GetDistinctDuplicates(IEnumerable<string> original)
    {
    	var dict = new Dictionary<string, bool>();
    	foreach (var s in original)
    	{
    		// If found duplicate 
    		if (dict.TryGetValue(s, out var isReturnedDupl))
    		{
    			// If already returned
    			if (isReturnedDupl)
    			{
    				continue;
    			}
    
    			dict[s] = true;
    			yield return s;
    		}
    		else 
    		{
    			// First meet
    			dict.Add(s, false);
    		}
    	}
    }
