    public static void Main(string[] args)
    {
    	List<List<int>> myList = new List<List<int>>();
        myList.Add(new List<int> { 2, 7, 3 });
	
        myList.Add(new List<int> { 4, 6});
    	myList.Add(new List<int> { 2, 5, 1 });
    	myList.Add(new List<int> { 7, 0, 2 });
    	myList.Add(new List<int> { 4, 9 });
    	var result = FindCommonSets(myList);
    }
    
    static List<HashSet<T>> FindCommonSets<T>(IEnumerable<IEnumerable<T>> data)
    {
        List<HashSet<T>> sets = new List<HashSet<T>>();
    	bool anyModified = false;
        foreach (var list in data)
        {
            //find a set which already overlaps this list.
            var set = sets.FirstOrDefault(s => s.Overlaps(list));
            if (set != null)
            {
                //if we find one, dump all the elements of this list into the set.
                set.UnionWith(list);
    			anyModified = true;
            }
            else
            {
                //if not, add a new set based on this list.
                sets.Add(new HashSet<T>(list));
            }
        }
    	if (anyModified)
    	{
            //run the whole thing again with the new data if anything was changed in this iteration.
    		return FindCommonSets(sets);
    	}
        return sets;
    }
