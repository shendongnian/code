    private static string _DBConnectionString = string.Empty;    
    public static int SetData(string sqlQuery)
    {
    	int iReturn = -1;
    	try
    	{
    		MySqlCommand cmd = new MySqlCommand(sqlQuery);
    		using (MySqlConnection conn = new MySqlConnection(DBConnectionString))
    		{
    			if (conn.State != ConnectionState.Open)
    				conn.Open();
    
    			cmd.Connection = conn;
    			iReturn = cmd.ExecuteNonQuery();
    
    			if (conn.State == ConnectionState.Open)
    				conn.Close();
    		}
    	}
    	catch (Exception E)
    	{
    		iReturn = -1;
    	   
    	}
    	return iReturn;
    }
                
    public static object GetData(string sqlQuery)
    {
    	DataSet dtSet = new DataSet();
    	try
    	{
    		MySqlCommand cmd = new MySqlCommand(sqlQuery);
    		MySqlDataAdapter adpt = new MySqlDataAdapter();
    
    		using (MySqlConnection conn = new MySqlConnection(DBConnectionString))
    		{
    			if (conn.State != ConnectionState.Open)
    				conn.Open();
    
    			cmd.CommandTimeout = 0;
    			adpt.SelectCommand = cmd;
    
    			cmd.Connection = conn;
    			adpt.Fill(dtSet);
    
    
    			if (conn.State == ConnectionState.Open)
    				conn.Close();
    		}
    	}
    	catch (Exception E)
    	{	
    	
    	}
    	return dtSet;
    }
        
