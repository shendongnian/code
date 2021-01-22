    public static SqlCommand CreateStoredProcCmd(string name, SqlConnection con)
    {
        var cmd = new SqlCommand(name, con);
        cmd.CommandType = CommandType.StoredProcedure;
        return cmd;
    }
    public static void AddParams(this SqlCommand cmdObject, Params SqlParameter[] parameters)
    {
      foreach(SqlParameter param in parameters)
      {
        cmdObject.Parameters.add(param);
      }
    }
    
    /* Any overloaded methods to create params receiving my param definitions 
    in any manner that the usual new SqlParameter() constructor doesn't handle */
    public static SqlParameter CreateSqlParam(string ParamName,
                                              SqlDbType ParamType,
                                              object value)
    {
        return CreateSqlParam(ParamName, ParamType, ParameterDirection.Input, value);
    }
    public static SqlParameter CreateSqlParam(string ParamName, 
                                              SqlDbType ParamType, 
                                              ParameterDirection ParamDir, 
                                              object value)
    {
        var parm = new SqlParameter(ParamName, ParamType);
        parm.Direction = ParamDir;
        parm.Value = value;
        return parm;
    }
