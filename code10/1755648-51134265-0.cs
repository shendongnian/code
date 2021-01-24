    var retryTimes = 3;
    var waitBetweenExceptions = TimeSpan.FromSeconds(10);
    
    var retryPolicy = Policy
        .Handle<OracleException>(e => e.Message.Contains("ORA-03114"))
        .WaitAndRetry(retryTimes, i => waitBetweenExceptions);
    
    await retryPolicy.Execute(() =>
    {
        string cs = "Data Source = 172.10.200.100:1521/dev;PERSIST SECURITY INFO=True;USER ID=test; Password=devtest;";
    	using (OracleConnection connection = new OracleConnection(cs)){
    	  connection.Open();
    	  using (OracleCommand cmd = connection.CreateCommand()) 
    	  {
    		cmd.CommandType = CommandType.StoredProcedure;
    		cmd.CommandText = "sp_check_db";
    		cmd.ExecuteNonQuery();
    		connection.Close();
    	  }
    	}
    });
