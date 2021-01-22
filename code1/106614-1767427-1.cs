    class SqlCode
    {
        internal void RunNonQuery(string query)
        {
            using (Connection cn = new Connection())
                cn.ExecuteNonQuery(query);
        }
        internal int RunScalar(string query)
        {
            using (Connection cn = new Connection())
                return cn.RunScalar(query);
        }
    }
