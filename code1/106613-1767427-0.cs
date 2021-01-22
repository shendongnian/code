    class Connection : IDisposable
    {
        readonly SqlConnection _conn;
        public Connection()
        {
            string connString = GetLocalConnectionString();
            _conn = new SqlConnection(connString);
            _conn.Open();
        }
        public void Dispose() { _conn.Dispose(); }
        public SqlCommand CreateCommand(string qry)
        {
            SqlCommand cmd = _conn.CreateCommand();
            cmd.CommandText = qry;
            //cmd.CommandTimeout = TimeSpan.FromMinutes(x);
            return cmd;
        }
        public int ExecuteNonQuery(string qry)
        {
            using (SqlCommand cmd = CreateCommand(qry))
                return cmd.ExecuteNonQuery();
        }
        public int RunScalar(string qry)
        {
            using (SqlCommand cmd = CreateCommand(qry))
                return int.Parse(cmd.ExecuteScalar().ToString());
        }
    }
