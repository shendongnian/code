    public static bool MetabasePathExists(string metabasePath)
    {
    	try
    	{
    		using(DirectoryEntry site = new DirectoryEntry(metabasePath))
    		{
    			if(site.Name != String.Empty)
    			{
    				return true;
    			}
    			return false;
    		}
    	}
    	catch(COMException ex)
    	{
    		if(ex.Message.StartsWith("The system cannot find the path specified"))
    		{
    			return false;
    		}
    		LogError(ex, String.Format("metabasePath={0}", metabasePath));
    		throw;
    	}
    	catch(Exception ex)
    	{
    		LogError(ex, String.Format("metabasePath={0}", metabasePath));
    		throw;
    	}
    }
