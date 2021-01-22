    public DataTable getData(string sql, int pgNo, int totalRows) 
    {
    DataTable dt = null;
            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                try
                {
                    DataSet ds;
                    conn.Open();
                    ds = new DataSet();
                    OleDbDataAdapter adapter = new OleDbDataAdapter(sql, conn);
                    adapter.Fill(ds, (pgNo-1)*totalRows, totalRows, "Table");
                    conn.Close();
                    dt = ds.Tables[0];
                }
                catch (Exception ex)
                {if (conn != null) conn.Dispose();}
    return dt;
    }
