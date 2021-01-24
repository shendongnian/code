    private DataTable QueryToTable(string sql, string cs)
    {
  
        var ds = new DataSet();
    
        using (var adapter = new SqlDataAdapter(sql, cs))
        {
            adapter.Fill(ds);
        }
    
        return ds.Tables(0);
    }
