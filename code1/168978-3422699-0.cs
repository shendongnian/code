      /// <summary>
        /// Sets the connection.
        /// </summary>
        public void SetConnection()
        {
            _connection = new SqlConnection(Settings.Default.connectionString);
            if (_connection.State == System.Data.ConnectionState.Open)
            {
                _connection.Close();
            }
            _connection.Open();
        }
    
    
        /// <summary>
        /// Closes the connection.
        /// </summary>
        public void CloseConnection()
        {
            if (_connection.State == System.Data.ConnectionState.Open)
            {
                _connection.Close();
                _connection.Dispose();
            }
        }
