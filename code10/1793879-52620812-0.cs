        public class DbConnection
        {
        public DbConnection(string connectionString)
        {
            _sqlConnection = new SqlConnection(connectionString);
        }
