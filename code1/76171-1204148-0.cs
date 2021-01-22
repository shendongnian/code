    IDbConnection conn = sql ? new SqlConnection(...) : new OracleConnection(...);
    // this will give you either an SqlCommand or an OracleCommand
    IDbCommand cmd = conn.CreateCommand();
    // this will give you either an SqlParameter or an OracleParameter
    IDbDataParameter param1 = cmd.CreateParameter();
    param1.ParameterName = "colIntB";
    param1.Value = objVal;
    cmd.Parameters.Add(param1);
