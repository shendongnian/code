    public static List<Dictionary<string, object>> RemoveItem(this List<Dictionary<string, object>> items, string value, string key)
    {
    	foreach (var item in items)
    	{
    		if(item.ContainsKey(key) && item[key] == value)
    		{
    			item.Remove(key);
    		}
    	}
    
    	return items;
    }
