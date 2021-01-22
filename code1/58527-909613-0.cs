    protected static SqlCommand CreateSprocCommand(SqlConnection con, string name, bool includeReturn, SqlDbType returnType)
    {
        SqlCommand com = new SqlCommand(name, con);
        com.CommandType = System.Data.CommandType.StoredProcedure;
    
        if (includeReturn)
            com.Parameters.Add("ReturnValue", returnType).Direction = ParameterDirection.ReturnValue;
    
        return com;
    }
