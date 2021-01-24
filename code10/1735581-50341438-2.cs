    public static class DB
    {
        private static readonly string ConnectionString = "Server=localhost;Database=test;Uid=root;Pwd='';SslMode=none";
        private static IEnumerable<T> GetData(string sql, Action<MySqlParameterCollection> SetParameters, Func<IDataRecord, T> transformRecord)
        {
            using (var mcon = new MySqlConnection(ConnectionString))
            using (var cmd = new MySqlCommand(sql, mcon))
            {
                if (SetParameters != null) SetParameters(cmd.Parameters);
                using (var rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        yield return transformRecord(rdr);
                    }
                    rdr.Close();
                }
            }   
        }
        public static IEnumerable<DateTime> GetDates()
        {           
            return GetData("SELECT dates FROM abctable", null,
                 r => (DateTime)r["dates"]);
        }
    }
