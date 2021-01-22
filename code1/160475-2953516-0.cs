    private static void ExecuteCommand(IDbConnection conn)
    {
        using (IDbCommand cmd = conn.CreateCommand())
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ProcedureName";
            IDataParameter param = cmd.CreateParameter();
            param.ParameterName = "@parameterName";
            param.Value = "parameter value";
            cmd.Parameters.Add(param);
            using (IDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    // get data from the reader
                }
            }
        }
    }
