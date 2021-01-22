    class Connection
    {
        internal string connectionString;
        public Connection(ConnectionPool pool, string connectionString) {
            this.pool = pool;
            //this.connectionString = connectionString; // I moved it because I could.
            this.pool.Register(this);
            this.connectionString = connectionString;
            this.Init();        
        }
        private void Init() { //blah }
    }
    class ConnectionPool
    {
         public void Register(Connection c)
         {
             if ( this.connStrings.Contains( c.connectionString ) ) // BOOM
         }
    }
    
