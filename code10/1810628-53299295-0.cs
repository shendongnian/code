    int count = 0;
    using (SqlConnection connection = new SqlConnection(connectionString))
    {
    	try{
	    	connection.Open();
		    foreach (var table in tables)
		    {
		        try{
		        	var cmd = "SELECT COUNT(*) FROM " + table;
		    		using(var sc as new SqlCommand(cmd, connection)){
						count += (int)sc.ExecuteScalar();
		    		}
		        }
		        catch {}
		    }
		}finally{
			connection.Close();
		}
    }
