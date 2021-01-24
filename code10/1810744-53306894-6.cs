    public class ConnectionManager
    {
        private string _connectionString;
        public ConnectionManager(string connectionString)
        {
            _connectionString = connectionString;
        }
        public void ExecuteNonQuery(string strSqlStatement)
        {
            using(var connection = new SqlConnection(_connectionString))
            using(var command = new SqlCommand(strSqlStatement, connection))
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
