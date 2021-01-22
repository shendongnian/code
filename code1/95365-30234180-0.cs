    //Because this is a long running stored procedure, we start is up in a new thread.
    using (SqlConnection conn = new   SqlConnection(ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["ConnectionStringName"]].ConnectionString))
    {
  	    try
	    {
	    	//Create a new instance SqlCommand.
    		SqlCommand command = new SqlCommand(ConfigurationManager.AppSettings["StoredProcedureName"], conn);
		    //Set the command type as stored procedure.
	    	command.CommandType = CommandType.StoredProcedure;
    		//Create input parameters.
		    command.Parameters.Add(CreateInputParam("@Param1", SqlDbType.BigInt, Param1));
	    	command.Parameters.Add(CreateInputParam("@Param2", SqlDbType.BigInt, Param3));
    		command.Parameters.Add(CreateInputParam("@Param3", SqlDbType.BigInt, Param3));
		    //Open up the sql connection.
	    	conn.Open();
    		//Create a new instance of type IAsyncResult and call the sp   asynchronously.
	    	IAsyncResult result = command.BeginExecuteNonQuery();
		     //When the process has completed, we end the execution of the sp.
    		command.EndExecuteNonQuery(result);
    	}
	    catch (Exception err)
	    {
		    //Write to the log.
	    }
    }
