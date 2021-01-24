    public DateTime GetArbeitStart(int userId)
    {
        using (IDbConnection connection = new System.Data.SqlClient.SqlConnection())
        {
            connection.ConnectionString = _ConnectionString;
            return connection.Query<DateTime>("select LPE_ArbeitStart from A_PERSONAL WHERE LPE_ID=" + userId)
                .DefaultIfEmpty(new DateTime(2018, 1, 1)).First();
        } 
    }
