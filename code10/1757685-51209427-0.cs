    internal static class MySqlDataManager
    {
        private static System.Data.DataSet GetMySqlDataSet(string usingQuery,
             string usingConnectionString, params MySqlParameter[] withParameters)
        {
            var ret = new System.Data.DataSet();
            using (var conn = new MySqlConnection(usingConnectionString))
            {
                using (var command = new MySqlCommand(usingQuery, conn))
                {
                    command.Parameters.AddRange(withParameters);
                    using (var adapter = new MySqlDataAdapter(command)) adapter.Fill(ret);
                }
                return ret;
            }
        }
    }
