    private static object _lock = new object();
    
    private List<string> SomeMethod(string ExtractField)
    {
    	List<string> Items = null;
    	try
    	{
    		lock (_lock)
    		{		
    			DataTable result = GetDataTable();
    			Items = result.AsEnumerable().AsParallel().Select(y => y.Field<string>(ExtractField)).ToList();
    			Items.RemoveAll(item => String.IsNullOrEmpty(item));			
    		}
    	}
    	catch (Exception ex)
    	{
    		// ...
    	}
    	return Items;
    }
