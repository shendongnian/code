    private IList<string> GetColumns(string columns)
    {
    	IList<string> list = new List<string>();
    
    	if (!string.IsNullOrWhiteSpace(columns))
    	{
    		if (columns[0] != '\"')
    		{
    			// treat as just one item
    			list.Add(columns);
    		}
    		else
    		{
    			bool gettingItemName = true;
    			bool justChanged = false;
    			string itemName = string.Empty;
    
    			for (int index = 1; index < columns.Length; index++)
    			{
    				justChanged = false;
    				if (subIndustries[index] == '\"')
    				{
    					gettingItemName = !gettingItemName;
    					justChanged = true;
    				}
    
    				if ((gettingItemName == false) &&
    				(justChanged == true))
    				{
    					list.Add(itemName);
    					itemName = string.Empty;
    					justChanged = false;
    				}
    
    				if ((gettingItemName == true) && (justChanged == false))
    				{
    					itemName += columns[index];
    				}
    			}
    		}
    	}
    
    	return list;
    }
