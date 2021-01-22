    DataSet ds = new DataSet();
    SqlDataAdapter da = new SqlDataAdapter(sqlString, sqlConn);
    da.Fill(ds);
    
    if(ds.Tables.Count > 0)
    {
      // enter code here
    }
