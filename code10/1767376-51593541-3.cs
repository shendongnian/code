    public static SortedDictionary<char, int> Count(string stringToCount)
    {
    	// Create a new empty SortedDictionary (use var keyword if defining variables)
    	var characterCount = new SortedDictionary<char, int>();
    	// Loop through each character and add to dictionary
	    foreach (var character in stringToCount)
	    {
	    	// If character already in SortedDictionary.
	    	if (characterCount.TryGetValue(character, out int count))
	    	{
	    		// Increment count value.
	    		characterCount[character] = count + 1;
	    		// Above line can also be: ++characterCount[character];
	    	}
	    	// Else, character not already in dictionary.
	    	else
	    	{
	    		// Add character in dictionary and set count to 1.
	    		characterCount.Add(character, 1);
	    	}
	    }
    	return characterCount;
    }
