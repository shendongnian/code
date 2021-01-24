    public DataTable GetTableBySQL(string sql, params SqlParameter[] parameters) 
    {
        var result = new DataTable();
        using (var dbconn = new SqlConnection(this.dbConnectionString))
        using (var cmd = new SqlCommand(sql, dbconn))
        using (var da = new SqlDataAdapter(cmd))
        {
            cmd.CommandTimeout = 0;
            if (parameters != null && parameters.Length > 0)
            {
                cmd.Parameters.AddRange(parameters);
            }
    
            da.Fill(result);
        }  
        return result;
    }
