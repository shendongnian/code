    public static IEnumerable<string> GetDuplicates(IEnumerable<string> original)
    {
    	var hs = new HashSet<string>();
    	foreach (var item in original)
    	{
    		if (!hs.Add(item))
    		{
    			yield return item;
    		}
    	}
    }
