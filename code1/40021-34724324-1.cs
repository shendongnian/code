    public static bool SequenceEqualUnordered<T>(IEnumerable<T> first, IEnumerable<T> second)
    {
    	if (first == null)
    		return second == null; // or throw if that's more appropriate to your use.
    	if (second == null)
    		return false;	// likewise.
    	var dict = new Dictionary<T, int>(); // You could provide a IEqualityComparer<T> here if desired.
    	foreach(T element in first)
    	{
    		int count;
    		dict.TryGetValue(element, out count);
    		dict[element] = count + 1;
    	}
    	foreach(T element in second)
    	{
    		int count;
    		if (!dict.TryGetValue(element, out count))
    			return false;
    		else if (--count == 0)
    			dict.Remove(element);
    		else
    			dict[element] = count;
    	}
    	return dict.Count == 0;
    }
