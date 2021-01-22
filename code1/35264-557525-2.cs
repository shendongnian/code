    public struct ConnectionManager : IDisposable
    {
        // The backing for the connection.
        private SqlConnection connection;
    
        // The connection.
        public SqlConnection Connection { get { return connection; } }
    
        public void Dispose()
        {
            // If there is no connection, get out.
            if (connection == null)
            {
                // Get out.
                return;
            }
    
            // Make sure connection is cleaned up.
            using (SqlConnection c = connection)
            {
                // See (1).  Create the command for sp_unsetapprole
                // and then execute.
                using (SqlCommand command = ...)
                {
                    // Execute the command.
                    command.ExecuteNonQuery();
                }
            }
        }
    
        public ConnectionManager Release()
        {
            // Create a copy to return.
            ConnectionManager retVal = this;
    
            // Set the connection to null.
            retVal.connection = null;
    
            // Return the copy.
            return retVal;        
        }
    
        public static ConnectionManager Create()
        {
            // Create the return value, use a using statement.
            using (ConnectionManager cm = new ConnectionManager())
            {
                // Create the connection and assign here.
                // See (2).
                cm.connection = ...
    
                // Create the command to call sp_setapprole here.
                using (SqlCommand command = ...)
                {
                    // Execute the command.
                    command.ExecuteNonQuery();
    
                    // Return the connection, but call release
                    // so the connection is still live on return.
                    return cm.Release();
                }
            }
        }
    }
