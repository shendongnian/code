    private Dictionary<String, Int32> GetCounts(DataTable dt)
    {
    	var result = new Dictionary<String, Int32>();
    
    	foreach (DataRow row in dt.Rows)
    	{
    		foreach (var v in row.ItemArray)
    		{
    			string key = (v ?? string.Empty).ToString();
    
    			if (!result.ContainsKey(key))
    			{
    				result.Add(key, 0);
    			}
    
    			result[key]++;
    		}
    	}
    
    	return result;
    }
