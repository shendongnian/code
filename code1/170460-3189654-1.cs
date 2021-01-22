    public static int IsCsInMaster(HashSet<string> childSubset, List<HashSet<string>> master, int startIndex)
    {
    	for (int i = startIndex; i < master.Count; i++)
    		if (childSubset.IsSubsetOf(master[i])) return i;
    
    	return -1;
    }
    
    public static bool IsChildInMaster(List<HashSet<string>> child, List<HashSet<string>> master)
    {
    	foreach (var childSubset in child) if (IsCsInMaster(childSubset, master, 0) == -1) return false;
    
    	return true;
    }
    
    public static bool IsChildInMasterMulti(List<HashSet<string>> child, List<HashSet<string>> master)
    {
    	Dictionary<int, int> subsetChecker = new Dictionary<int, int>();
    	List<IEnumerable<int>> multiMatches = new List<IEnumerable<int>>();
    	int subsetIndex;
    
    	// Check for matching subsets.
    	for (int i = 0; i < child.Count; i++)
    	{
    		subsetIndex = 0;
    		List<int> indexes = new List<int>();
    
    		while ((subsetIndex = IsCsInMaster(child[i], master, subsetIndex)) != -1)
    		{
    			indexes.Add(subsetIndex++);
    		}
    
    		if (indexes.Count == 1)
    		{
    			subsetIndex = indexes[0];
    			if (subsetChecker.ContainsKey(subsetIndex)) return false;
    			else subsetChecker[subsetIndex] = subsetIndex;
    		}
    		else
    		{
    			multiMatches.Add(indexes);
    		}
    	}
    
    	/*** Check for multi-matching subsets. ***/ //got lazy ;)
    	var union = multiMatches.Aggregate((aggr, indexes) => aggr.Union(indexes));
    
    	// Filter the union so only unmatched subset indexes remain.
    	List<int> filteredUion = new List<int>();
    	foreach (int index in union)
    	{
    		if (!subsetChecker.ContainsKey(index)) filteredUion.Add(index);
    	}
    
    	return (filteredUion.Count >= multiMatches.Count);
    }
