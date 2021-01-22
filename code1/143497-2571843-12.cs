    //part of the data layer
    private static IEnumerable<IDataRecord> Retrieve(string sql, Action<SqlCommand> addParameters)
    {
        //DL.ConnectionString is a private static property in the data layer
        // depending on the project needs, it can be implementing to read from a config file or elsewhere
        using (var cn = new SqlConnection(DL.ConnectionString))
        using (var cmd = new SqlCommand(sql, cn))
        {
            addParameters(cmd);
            cn.Open();
            using (var rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                  yield return rdr;
            }
        }
    }
