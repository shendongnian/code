    public class DefaultDatabaseConnection: IDatabaseConnection
    {
        private string _Name { get; set; }
        public string Name
        {
            get
            {
                return _Name;
            }
            private set
            {
                _Name = value;
            }
        }
        public DefaultDatabaseConnection()
        {
             Name = "DefaultConnection";
        }
        public DefaultDatabaseConnection(string connectionName)
        {
            Name = connectionName;
        }
    }
