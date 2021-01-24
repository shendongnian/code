    public static SortedDictionary<char, int> Count(string stringToCount)
    {
    	// Create a new empty SortedDictionary (use var keyword if defining variables)
    	var characterCount = new SortedDictionary<char, int>();
        // Loop through each character and add to dictionary
    	foreach (var character in stringToCount)
    	{
    		// If character not already in SortedDictionary.
    		if(!characterCount.ContainsKey(character))
    		{
    			// Add character in dictionary and set count to 1.
    			characterCount.Add(character, 1);
    		}
		    // Else, character must already be in dictionary.
		    else
		    {
		    	// Increment count value.
		    	++characterCount[character];
	    	}
	    }
    	return characterCount;
    }
