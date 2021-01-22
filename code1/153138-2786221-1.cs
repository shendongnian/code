    public class MyConnectionStrings
    {
        private string GetConnectionString(string connectionName) { ... }
        public string this[string connectionName]
        {
            get { return GetConnectionString(connectionName); }
        }
    }
