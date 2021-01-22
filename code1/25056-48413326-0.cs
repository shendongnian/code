    string debugSQL = dbCommand.CommandText;
    foreach (SqlParameter param in dbCommand.Parameters)
    {
        string val = param.Value.ToString();
        switch (param.DbType)
        {
            case System.Data.DbType.AnsiString:
                    val = "'" + val + "'";
                break;
            case System.Data.DbType.Boolean:
                val = (val == "True" ? "1" : "0");
                break;
        }
        debugSQL = debugSQL.Replace("@" + param.ParameterName, val);
    }
