    public class DefaultDatabaseConnection: IDatabaseConnection
    {
        public string Name { get; private set; }
        public DefaultDatabaseConnection()
        {
             Name = "DefaultConnection";
        }
        public DefaultDatabaseConnection(string connectionName)
        {
            Name = connectionName;
        }
    }
