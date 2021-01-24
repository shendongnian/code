    public interface ISQLiteAsyncProvider {
        SQLiteAsyncConnection GetConnection();
    }
    
    public class DefaultSQLiteAsyncProvider : ISQLiteAsyncProvider {
        private readonly Lazy<SQLiteAsyncConnection> connection;
        public DefaultSQLiteAsyncProvider(string path) {
            connection = new Lazy<SQLiteAsyncConnection>(() => new SQLiteAsyncConnection(path));
        }
    
        public SQLiteAsyncConnection GetConnection() {
            return connection.Value;
        }
    }
