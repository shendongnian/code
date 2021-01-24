    public bool CompareUsingDictionary(IEnumerable<T> firstCollection, IEnumerable<T> secondCollection)
    	{
    		// Implementation needs overiding GetHashCode methods of the object base class in the compared type
    		// Obviate initial test cases, if either collection equals null and other doesn't then return false. If both are null then return true.
    		if (firstCollection == null && secondCollection != null)
    			return false;
    		if (firstCollection != null && secondCollection == null)
    			return false;
    		if (firstCollection == null && secondCollection == null)
    			return true;
    
    		// Create a dictionary with key as Hashcode and value as number of occurences
    		var dictionary = new Dictionary<int, int>();
    
    		// If the value exists in first list , increase its count
    		foreach (T item in firstCollection)
    		{
    			// Get Hash for each item in the list
    			int hash = item.GetHashCode();
    
    			// If dictionary contains key then increment 
    			if (dictionary.ContainsKey(hash))
    			{
    				dictionary[hash]++;
    			}
    			else
    			{
    				// Initialize he dictionary with value 1
    				dictionary.Add(hash, 1);
    			}
    		}
    
    		// If the value exists in second list , decrease its count
    		foreach (T item in secondCollection)
    		{
    			// Get Hash for each item in the list
    			int hash = item.GetHashCode();
    
    			// If dictionary contains key then decrement
    			if (dictionary.ContainsKey(hash))
    			{
    				dictionary[hash]--;
    			}
    			else
    			{
    				return false;
    			}
    		}
    
    		// Check whether any value is 0
    		return dictionary.Values.Any(numOfValues => numOfValues == 0);
    	}
