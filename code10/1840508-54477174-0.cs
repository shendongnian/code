    if(EndDate < DateTime.Now.Date)		// Assuming EndDate is already defined in your class 
    {
    	using(SqlConnection sqlCon = new SqlConnection(sqlCon.ConnectionString) )
    	using(SqlCommand sqlCmd = new SqlCommand("DeleteByDate", sqlCon))
    	{
    		sqlCon.Open();
    		sqlCmd.CommandType = CommandType.StoredProcedure;
    		sqlCmd.ExecuteNonQuery();	
    	}	
    }
    		
