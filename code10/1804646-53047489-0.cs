    public interface IConnection
    {
        void Connect();
    }
    public class PostgresConnection : IConnection
    {
        public void Connect()
        {
        ...
        }
    }
    public class SqliteConnection : IConnection
    {
        public void Connect()
        {
        ...
        }
    }
    public static class DatabaseConnectionFactory
    {
        public static string PostgreSQLConnectionString { get; set; }
        public static string SQLiteConnectionString { get; set; }
        public static IConnection Create(string connectiontype)
        {
            switch (connectiontype)
            {
                case "PostgreSQL":
                    PostgresConnection postgresConnection = new PostgresConnection();
                    return postgresConnection;
                case "SQLite":
                    SQLiteConnection sqliteConnection = new SQLiteConnection();
                     return sqliteConnection;
            }
            return null;
        }
    }
