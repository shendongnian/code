    void Main()
    {
    	string values = @"1
      14
        141
            141010
            141020
            141030
            141040
            141050
            141060
        142
            142010
            142020
        144
           1440
              144010
              144020
              144030
              144040
        145020
        145030
        145010
              ";
    
    	int myValue;
    // Splitting and converting to a collection of integers ordered by randomly
    // just to show initial order doesn't matter
    	var myData = values.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
    		.Select(s => int.TryParse(s.Trim(), out myValue) ? myValue : -1)
    		.Where(n => n != -1)
    		.OrderBy(n => Guid.NewGuid());
    
    // We have the collection. Sort it "directory" style
    	List<string> myList = new List<string>();
    	var list = myData.Select(d => d.ToString());
    	foreach (var v in myData)
    	{
    		myList.Add(Fullpath(v.ToString(), list));
    	}
    	var ordered = myList.OrderBy(l => l);
    // Write out the result intended
    	foreach (var element in ordered)
    	{
    		var levels = element.Count(e => e == '/');
    		var value = levels > 0 ? element.Remove(0, element.LastIndexOf('/') + 1) : element;
    		Console.WriteLine("".PadLeft(levels, '\t') + value);
    	}
    }
    
    // Get the full path for a value with ancestors
    // ie: 1/14/1440/144010 is the full path for 144010
    private string Fullpath(string key, IEnumerable<string> list)
    {
    	List<string> paths = new List<string>();
    	for (int i = 1; i <= key.Length; i++)
    	{
    		if (list.Any(v => key.Substring(0, i) == v))
    		{
    			paths.Add(key.Substring(0, i));
    		}
    	}
    	return string.Join("/", paths);
    }
