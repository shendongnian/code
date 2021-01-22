    System.Data.OracleClient.OracleCommand command = new System.Data.OracleClient.OracleCommand("PACKAGE_NAME.STORED_NAME");
    command.CommandType = System.Data.CommandType.StoredProcedure;
    
    System.Data.OracleClient.OracleParameter param;
    param = new System.Data.OracleClient.OracleParameter("PARAM_NAME_ID", System.Data.OracleClient.OracleType.Number);
    param.Value = id;
    command.Parameters.Add(param);
    
    param = new System.Data.OracleClient.OracleParameter("PARAM_NAME_RETURN_COUNT", System.Data.OracleClient.OracleType.Number);
    param.Direction = System.Data.ParameterDirection.Output;
    command.Parameters.Add(param);
    ...
