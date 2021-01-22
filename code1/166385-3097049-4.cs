    IEnumerable<T> GetData<T>(Func<IDataRecord, T> factory, string sql, Action<SqlParameterCollection> addParameters)
    {
        using (var cn = new SqlConnection("My connection string"))
        using (var cmd = new SqlCommand(sql, cn))
        {
            addParameters(cmd.Parameters);
    
            cn.Open();
            using (var rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                  yield return factory(rdr);
            }
        }
    }
    
