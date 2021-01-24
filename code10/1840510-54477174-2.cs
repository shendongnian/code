    if(EndDate < DateTime.Now.Date)		// Assuming EndDate is already defined in your class 
    {
    	using(SqlConnection sqlCon = new SqlConnection(sqlCon.ConnectionString) )
    	using(SqlCommand sqlCmd = new SqlCommand("DeleteByDate", sqlCon))
    	{
    		sqlCon.Open();
    		sqlCmd.CommandType = CommandType.StoredProcedure;
    		sqlCmd.Parameters.Add("@AdvID", SqlDbType.Int);
    		sqlCmd.Parameters["@AdvID"].Value = AdvID //Assuming it's already defined;
    		sqlCmd.ExecuteNonQuery();	
    	}	
    }
        	
	
