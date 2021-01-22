    class ProgramCore : IDisposable
    {
        internal ProgramCore(string sourceConnectionString, string destinationConnectionString)
        {
            setUpConnections(sourceConnectionString, destinationConnectionString);
        }
        internal void Execute()
        {
            // do whatever you want
            doDatabaseWork();
            // do whatever you want
        }
        public void Dispose()
        {
            if (_sourceConnection != null)
                _sourceConnection.Dispose();
            if (_destinationConnection != null)
                _destinationConnection.Dispose();
        }
        private void setUpConnections(string sourceConnectionString, string destinationConnectionString)
        {
            _sourceConnection = new SQLiteConnection(sourceConnectionString);
            _destinationConnection = new SQLiteConnection(destinationConnectionString);
        }
        private void doDatabaseWork()
        {
            // use the connections here
        }
        private SQLiteConnection _sourceConnection;
        private SQLiteConnection _destinationConnection;
    }
    class Program
    {
        static void Main(string[] args)
        {
            // get connection strings from command line arguments
            string sourceConnectionString = GetConnectionString(args);
            string destinationConnectionString = GetConnectionString(args);
            using (ProgramCore core = new ProgramCore(sourceConnectionString, destinationConnectionString))
            {
                core.Execute();
            }
        }
        static string GetConnectionString(string[] args)
        {
            // provide parsing here
        }
    }
