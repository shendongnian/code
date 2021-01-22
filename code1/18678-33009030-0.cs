    using (SqlConnection conn = new SqlConnection(...))
    {
        SqlCommand cmd = new SqlCommand("sproc", conn);
        cmd.CommandType = CommandType.StoredProcedure;
    
        // add other parameters parameters
    	
    	//Add the output parameter to the command object
    	SqlParameter outPutParameter = new SqlParameter();
    	outPutParameter.ParameterName = "@Id";
    	outPutParameter.SqlDbType = System.Data.SqlDbType.Int;
    	outPutParameter.Direction = System.Data.ParameterDirection.Output;
    	cmd.Parameters.Add(outPutParameter);
    
        conn.Open();
    	cmd.ExecuteNonQuery();
    
    	//Retrieve the value of the output parameter
    	string Id = outPutParameter.Value.ToString();
    
        // *** read output parameter here, how?
        conn.Close();
    }
