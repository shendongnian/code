    public static void WaitLock<T>() where T : class
    {
    	using (var db = GetDataContext())
    	{
    		var tableName = typeof(T).Name;
    		var count = 0;
    		while (true)
    		{
    			var recordsUpdated = db.ExecuteCommand("UPDATE LockedTable SET IsLocked = 1 WHERE TableName = '" + tableName + "' AND IsLocked = 0");
    			if (recordsUpdated <= 0)
    			{
    				Thread.Sleep(2000);
    				count++;
    				if (count > 50)
    					throw new Exception("Timeout getting lock on table: " + tableName);
    			}
    			else
    			{
    				break;
    			}
    		}
    	}
    }
   
    public static void ReleaseLock<T>() where T : class
    {
    	using (var db = GetDataContext())
    	{
    		var tableName = typeof(T).Name;
    		db.ExecuteCommand("UPDATE LockedTable SET IsLocked = 0 WHERE TableName = '" + tableName + "' AND IsLocked = 1");
    	}
    }
    public static void GetContactCode(int id)
    {
    	int tries = 0;
    	try
    	{
    		WaitLock<Contact>();
    		using (var db = GetDataContext())
    		{
    			try
    			{
    				var ct = // get contact
    				var maxCode = // maximum code
    				ct.Code = // generate next
    				db.SubmitChanges();
    			}
    			catch
    			{
    			}
    		}
    	}
    	catch
    	{
    		Thread.Sleep(2000);
    		tries++;
    		if (tries > 15)
    			throw new Exception("Timeout, try again.");
    	}
    	finally
    	{
    		ReleaseLock<Contact>();
    	}
    }
