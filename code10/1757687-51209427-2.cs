    internal static class MySqlDataManager
    {
        internal static System.Data.DataSet GetMySqlDataSet(string usingQuery,
             string usingConnectionString, params MySqlParameter[] withParameters)
        {
            using (var conn = new MySqlConnection(usingConnectionString))
            using (var command = new MySqlCommand(usingQuery, conn))
            {
                command.Parameters.AddRange(withParameters);
                var ds = new System.Data.DataSet();
                using (var adapter = new MySqlDataAdapter(command)) adapter.Fill(ds);
                return ds;
            }
        }
    }
