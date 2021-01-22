    /// <summary>Remove extraneous entries for common word permutations</summary>
    /// <param name="input">Incoming series of words to be filtered</param>
    /// <param name="MaxIgnoreLength">Words this long or shorter will not count as duplicates</param>
    /// <param name="words2">Instance list from BuildInstanceList()</param>
    /// <returns>Filtered list of lines from input, based on filter info in words2</returns>
    private static List<string> FilterNearDuplicates(List<string> input, int MaxIgnoreLength, List<dynamic> words2)
    {
    	List<string> output = new List<string>();
    	foreach (string line in input)
    	{
    		int Dupes = 0;
    		foreach (string word in line.Split(new char[] { ' ', ',', ';', '\\', '/', ':', '\"', '\r', '\n', '.' })
    			.Where(p => p.Length > MaxIgnoreLength)
    			.Distinct())
    		{
    			int Instances = 0;
    			foreach (dynamic dyn in words2)
    			if (word == dyn.Word)
    			{
    				Instances = dyn.Instances;
    				if (Instances > 1)
    					Dupes++;
    				break;
    			}
    		}
    		if (Dupes == 0)
    			output.Add(line);
    	}
    	return output;
    }
    /// <summary>Builds a list of words and how many times they occur in the overall list</summary>
    /// <param name="input">Incoming series of words to be counted</param>
    /// <returns></returns>
    private static List<dynamic> BuildInstanceList(List<string> input)
    {
    	List<dynamic> words2 = new List<object>();
    	foreach (string line in input)
    	foreach (string word in line.Split(new char[] { ' ', ',', ';', '\\', '/', ':', '\"', '\r', '\n', '.' }))
    	{
    		if (string.IsNullOrEmpty(word))
    			continue;
    		else if (ExistsInList(word, words2))
    			for (int i = words2.Count - 1; i >= 0; i--)
    			{
    				if (words2[i].Word == word)
    					words2[i] = new { Word = words2[i].Word, Instances = words2[i].Instances + 1 };
    			}
    		else
    			words2.Add(new { Word = word, Instances = 1 });
    	}
    
    	return words2;
    }
    /// <summary>Determines whether a dynamic Word object exists in a List of this dynamic type.</summary>
    /// <param name="word">Word to look for</param>
    /// <param name="words">Word dynamics to search through</param>
    /// <returns>Indicator of whether the word exists in the list of words</returns>
    private static bool ExistsInList(string word, List<dynamic> words)
    {
    	foreach (dynamic dyn in words)
    		if (dyn.Word == word)
    			return true;
    	return false;
    }
