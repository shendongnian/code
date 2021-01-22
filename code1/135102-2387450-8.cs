    private SqlConnection GetConnection()
    {
        var conn = new SqlConnection( /* connection string loaded from config file */ );
        conn.Open();
        return conn;
    }
    private static IEnumerable<IDataRecord> ExecuteEnumerable(this SqlCommand command)
    {
        using (var rdr = command.ExecuteReader())
        { 
            while (rdr.Read())
            {
                yield return rdr;
            }
        }
    }
    public  IEnumerable<IDataRecord> SomeQuery(int SomeParameter)
    {
        string sql = " .... ";
        using (var cn = GetConnection())
        using (var cmd = new SqlCommand(sql, cn))
        {
            cmd.Parameters.Add("@Someparameter", SqlDbType.Int).Value = SomeParameter;
            return cmd.ExecuteEnumerable();
        }
    }
