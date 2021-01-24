    public class DefaultDatabaseConnection: IDatabaseConnection
    {
        public string Name { get; private set; }
        public DefaultDatabaseConnection()
        {
             NameOrConnectionString = "DefaultConnection";
        }
        public DefaultDatabaseConnection(string connectionName)
        {
            NameOrConnectionString = connectionName;
        }
    }
