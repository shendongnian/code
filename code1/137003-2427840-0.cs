    public static IEnumerable<string> SplitBySize(string value, IEnumerable<int> sizes)
    {
    	if (value == null) throw new ArgumentNullException("value");
    	if (sizes == null) throw new ArgumentNullException("sizes");
    
    	var length = value.Length;
    	var currentIndex = 0;
    	foreach (var size in sizes)
    	{
    		var nextIndex = currentIndex + size;
    		if (nextIndex > length)
    		{
    			throw new ArgumentException("The sum of the sizes specified is larger than the length of the value specified.", "sizes");
    		}
    		yield return value.Substring(currentIndex, size);
    		currentIndex = nextIndex;
    	}
    }
