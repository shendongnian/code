    public class SqlServerDatabaseRepository
    {
        readonly string _connectionString;
    
        public SqlServerDatabaseRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
    
        public void ExecuteUserLogs(string userId, /* additional parameters */)
        {
            using(var connection = new SqlConnection(_connectionString)
            {
                //use your connection here to execute your command
            }   //here the connection falls out of scope so the using statement will handle disposing it for you
        }
    }
