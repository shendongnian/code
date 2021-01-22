    public class ConnectionFactoryBase {
        // This is an actual implementation that's shared by subclasses,
        // which is why we don't want an interface
        public string ConnectionString { get; set; }
        // Subclasses will provide database-specific implementations,
        // but there's nothing the base class can provide
        public abstract IDbConnection GetConnection() {}
    }
    public class SqlConnectionFactory {
        public override IDbConnection GetConnection() {
            return new SqlConnection(this.ConnectionString);
        }
    }
