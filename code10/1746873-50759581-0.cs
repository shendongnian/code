    public class DbConnectionFactory
    {
        public IDbConnection GetConnection() 
        {
            var connection = new SQLiteConnection("Data Source=mydb.sqlite;Version=3;");
            connection.Open();
            return connection;
        }
    }
