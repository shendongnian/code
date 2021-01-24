    static void Main(string[] args)
    {
        // PREPARING SAMPLE DATA   
    	List<string> duplicateIds = new List<string>();
    	List<List<string>> allItems = new List<List<string>>();
    
    	for (int i = 0; i < 5; i++)
    	{
    		var items = new List<string>();
    
    		for (int j = 0; j < 3; j++)
    		{
    			if (j == 0)
    				items.Add("id00" + (i + 1));
    			else if (i == 2)
    				items.Add("" + (j * 11));
    			else
    				items.Add("" + (j * 10));
    		}
    
    		allItems.Add(items);
    	}
    	
    	//PREPARING OPERATIONAL DATA. COVERTING RAW DATA TO DICTIONARY WHICH KEY IS 0TH ELEMENT (ID)
    	var allValues = new Dictionary<string, List<string>>();
    	allItems.ForEach(l => allValues.Add(l[0], l.Skip(1).ToList()));
    
    	// FINDING DUPLICATE IDS
    	foreach (var key1 in allValues.Keys)
    	{
    		foreach (var key2 in allValues.Keys)
    		{
    			if (key1 != key2)
    			{
    				var diff = allValues[key1].Except(allValues[key2]);
    
    				if (!diff.Any())
    				{
    					if (!duplicateIds.Contains(key2))
    						duplicateIds.Add(key2);
    				}
    			}
    		}
    	}
    
    	//SORTING DUPLICATE IDS AS NEED TO KEEP FIRST INDEX. REMOVING FIRST ITEM AS NEED TO KEEP THAT ITEM
    	//THIS IS MOST IMPORTANT PART OF THIS FLOW
    	duplicateIds.Sort();
    	duplicateIds = duplicateIds.Skip(1).ToList();
    
    	//DISPLAYING ON CONSOLE
    	allItems.ForEach(l => Console.WriteLine(l[0] + "=>" + string.Join(",", l)));
    	Console.WriteLine("Duplicate IDs =>" + string.Join(",", duplicateIds));
    
    	Console.ReadLine();
    }
