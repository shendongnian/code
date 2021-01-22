    class ConnectionProperties
    {
        private String _name;
        private String _dataSource;
        private String _username;
        private String _password;
        private String _initCatalogue;
        /// <summary>
        /// Basic Connection Properties constructor
        /// </summary>
        public ConnectionProperties()
        {
        }
        /// <summary>
        /// Constructor with the needed settings
        /// </summary>
        /// <param name="name">The name identifier of the connection</param>
        /// <param name="dataSource">The url where we connect</param>
        /// <param name="username">Username for connection</param>
        /// <param name="password">Password for connection</param>
        /// <param name="initCat">Initial catalogue</param>
        public ConnectionProperties(String name,String dataSource, String username, String password, String initCat)
        {
            _name = name;
            _dataSource = dataSource;
            _username = username;
            _password = password;
            _initCatalogue = initCat;
        }
    // Enter corresponding Properties here for access to private variables
    }
