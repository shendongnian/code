    public string GetCustomerNumber(Guid id)
    {
        var obj = 
            DBSqlHelperFactory.ExecuteScalar(
                connectionStringSplendidmyApp, 
                CommandType.StoredProcedure, 
                "GetCustomerNumber", 
                new SqlParameter("@id", id)
            );
        return obj.TrimString();
    }
