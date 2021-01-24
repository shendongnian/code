    public DataTable GetTableBySQL(string sql, params SqlParameter[] parameters) 
    {
        var result = new DataTable();
        //ADO.Net really does work better when you create a **NEW** connection
        //  object for most queries. Just share the connection string.
        //Also: "using" blocks are a better way to make sure the connection is closed.
        using (var dbconn = new SqlConnection(this.dbConnectionString))
        using (var cmd = new SqlCommand(sql, dbconn))
        using (var da = new SqlDataAdapter(cmd))
        {
            cmd.CommandTimeout = 0;
            // A number of the properties set on the cmd and tbl variables just set the same value that was already there, didn't accomplish anything
            //It's hard to understate how important it is to use parameterized queries.
            if (parameters != null && parameters.Length > 0)
            {
                cmd.Parameters.AddRange(parameters);
            }
            try
            {
                da.Fill(result);
            } 
            catch (SqlException e) 
            {
                this.HandleSQLError(e, "GetTableBySQL", sql.ToString());
                //you may want to re-throw here, 
                // or even just remove the try/catch and let the error bubble up to calling code
            }
        }  
        return result;
    }
