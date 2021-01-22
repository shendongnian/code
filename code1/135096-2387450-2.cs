    public SqlConnection GetConnection()
    {
        var conn = new SqlConnection( /* connection string loaded from config file */ );
        conn.Open();
        return conn;
    }
    public  IEnumerable<IDataRecord> SomeQuery(int SomeParameter)
    {
        string sql = ".... ";
        using (var cn = GetConnection())
        using (var cmd = new SqlCommand(sql, cn))
        {
            cmd.Parameters.Add("@Someparameter", SqlDbType.Int).Value = SomeParameter;
      
            using (var rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                {
                    yield return rdr;
                }
            }
        }
    }
