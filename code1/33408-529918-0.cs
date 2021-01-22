    // proc is the procedure name, oraConn is the oracle connection
    OracleCommand cmd = new OracleCommand(proc, oraConn);
    cmd.CommandType = System.Data.CommandType.StoredProcedure;
    
    OracleParameter ret = new OracleParameter();
    ret.Direction = System.Data.ParameterDirection.ReturnValue;
    ret.OracleType = OracleType.Number;
    cmd.Parameters.Add(ret);
