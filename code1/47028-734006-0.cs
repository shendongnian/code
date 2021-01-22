    public static DataSet GetTableSchema(string tableName)
    {
        string query = string.Format("SELECT TOP 0 * FROM {0}", tableName);
    
        using (SqlConnection localSqlConn = new SqlConnection(GetConnectionString()))
        {
            DataSet ds = new DataSet();
    
            SqlCommand sqlCmd = new SqlCommand(query, localSqlConn);
            SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
            
            sda.FillSchema(ds, SchemaType.Source, tableName);
            sda.Fill(ds, tableName);
    
            sda.Dispose();
    
            return ds;
        }
    }
