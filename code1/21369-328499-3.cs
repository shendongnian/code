    SqlConnection conn = null;
    try
    {
    	//create connection
    	
    	SqlCommand cmd = null;
    	try
    	{
    		//create command
    		
    		SqlDataReader reader = null;
    		try 
    		{
    			//create reader
    		}
    		finally
    		{
    			reader.Dispose();
    		}
    	}
    	finally
    	{
    		cmd.Dispose();
    	}
    }
    finally 
    {
    	conn.Dispose();
    }
