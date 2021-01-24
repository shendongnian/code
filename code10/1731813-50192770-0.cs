     public SqlConnection GetConnection()
        {
            SqlConnection connection = new SqlConnection(connectionString);
                if (connection.State == ConnectionState.Closed)                
                    connection.Open();
                
                return connection;            
        }
