    using (var connection = new OracleConnection("<connection string>"))
    {
    	var command = new OracleCommand();
    	command.Connection = connection;
    	command.CommandText = 
    		"declare v_bool boolean;" + 
    		"begin " +
    		"v_bool := auth_com.is_valid_username (:username); "+
    		"if (v_bool = TRUE) then select 1 into :v_result from dual; end if; " +
    		"if (v_bool = FALSE) then select 0 into :v_result from dual; end if; " +
    		"end;";
    		
    	command.Parameters.Add(new OracleParameter { ParameterName = "username", OracleDbType = OracleDbType.NVarchar2, Size=512, Direction = ParameterDirection.Input });
    	command.Parameters.Add(new OracleParameter { ParameterName = "v_result", OracleDbType = OracleDbType.Decimal, Direction = ParameterDirection.Output });		
    
    	try
    	{
    		connection.Open();
    		command.ExecuteNonQuery();
    	}
    	finally
    	{
    		connection.Close();
    	}
    
    	bool success = Convert.ToBoolean(((OracleDecimal)command.Parameters["v_result"].Value).ToInt32());
    }
