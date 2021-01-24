    public List<string> ZipStringLists(params List<string>[] lists)
    {
    	var columnNo = new int[lists.Length];
    	var resultingList = new List<string>();
    	var stringBuilder = new StringBuilder();
    
    	while (columnNo[0] < lists[0].Count)
    	{
    		// Combine the items into one: Apple + Banana + Pear = AppleBananaPear
    		for (int i = 0; i < lists.Length; i++)
    		{
    			var listElement = lists[i];
    			// columnNo[i] contains which column to write out for the individual list
    			stringBuilder.Append(listElement[columnNo[i]]);
    		}
    
    		// Write out the result and add it to a result list for later retrieval
    		Console.WriteLine(stringBuilder.ToString());
    		stringBuilder.Clear();
    
    		// We increment columnNo from the right to the left
    		// The next item after AppleBedBen is AppleBedBob
    		// Overflow to the next column happens when a column reaches its maximum value 
    		for (int i = lists.Length - 1; i >= 0; i--)
    		{
    			if (++columnNo[i] == lists[i].Count 
    					&& i != 0 /* The last column overflows when the computation finishes */)
    			{
    				// Begin with 0 again on overflow and continue to add to the next column
    				columnNo[i] = 0;
    			}
    			else
    			{
    				// No overflow -> stop
    				break;
    			}
    		}
    
    	}
    
    	return resultingList;
    }
