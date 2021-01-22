    class SqlOpener : IDisposable
    {
        SqlConnection _connection;
        public SqlOpener(SqlConnection connection)
        {
            _connection = connection;
            _connection.Open();
        }
        void IDisposable.Dispose()
        {
            _connection.Close();
        }
    }
    public class SomeDataClass : IDisposable
    {
        private SqlConnection _conn;
        //constructors and methods
        private void DoSomethingWithTheSqlConnection()
        {
            //some code excluded for brevity
            using (SqlCommand cmd = new SqlCommand("some sql query", _conn))
            using(new SqlOpener(_conn))
            {
                int countOfSomething = Convert.ToInt32(cmd.ExecuteScalar());
            }
            //some code excluded for brevity
        }
        public void Dispose()
        {
            _conn.Dispose();
        }
    }
