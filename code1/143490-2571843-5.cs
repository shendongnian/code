    IEnumerable<IDataRecord> MyQuery()
    {
        string sql="some query";
        using (var cn = new SqlConnection("connection string"))
        using (var cmd = new SqlCommand(sql, cn))
        {
            cn.Open();
            using (var rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                  yield return rdr;
            }
        }
    }
    
