    public static bool DoesRecordExist(DataTable dt, Dictionary<string,string> searchDetails) 
    {
    	if (dt != null && dt.Rows.Count > 0) {
    		var items = dt.AsEnumerable();
    		foreach(var searchItem in searchDetails)
    		{
    			items = items.Where(r=>string.Equals(SafeTrim(r[searchItem.Key]), searchItem.Value, StringComparison.CurrentCultureIgnoreCase)
    		}
    		return items.Any();
    	} 
    	else 
    	{
    		return false;
    	}
    }
