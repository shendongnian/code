    DataReader MyQuery()
    {
        string sql="some query";
        using (var cn = new SqlConnection("connection string"))
        using (var cmd = new SqlCommand(sql, cn))
        {
            cn.Open();
            return cmd.ExecuteReader();
        }
    }
    using (var rdr = MyQuery())
    {
        while (rdr.Read())
        {
            //...
        }
    }
