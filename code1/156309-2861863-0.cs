    // delegate to use for adding parameters
    delegate void AddParametersDelegate(IDbCommand cmd);
    IDataReader GetReader(SomeEnumType val, AddParametersDelegate addParms)
    {
        string sql = null;
    
        switch (val)
        {
            case EnumVal1:
                sql = "SQL Statement 1";
                break;
            case EnumVal2:
                sql = "SQL Statement 2";
                break;
            .
            default:
                sql = "Default SQL Statement";
                break;
        }
        using (IDbConnection conn = CreateDBConnection(connString))
        {
            using (IDbCommand cmd = conn.CreateCommand(sql))
            {
                // call the delegate to add the parameters to the SQL command
                addParams(cmd);
                return cmd.ExecuteReader(sql);
            }
        }
    }
