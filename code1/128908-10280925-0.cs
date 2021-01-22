    public bool ExecuteCMD(string Command) 
    {
    	using (var entities = new DbEntities())
    	{
    		var conn = new System.Data.EntityClient.EntityConnection(entities.Connection.ConnectionString);
    		try
    		{
    			conn.Open();
    			using (EntityCommand cmd = conn.CreateCommand())
    			{
    				cmd.CommandText = "DbEntities." + Command;
    				cmd.CommandType = System.Data.CommandType.StoredProcedure;
    				cmd.ExecuteNonQuery();
    			}
    			return true;
    		}
    		catch
    		{
    		    return false;
    		}
    		finally
    		{
    			if (conn != null)
    			{
    				conn.Close();
    			}
    		}
    	}
    }
