    private void myFunc()
    {
        // The ensureConnection method does the null check and creates a connection
        bool connectionEstablished;
        SqlConnection connection = ensureConnection(out connectionEstablished);
        try
        {
           // Do some work with the connection.
    
        }
        finally
        {
           // If the connection was established for this call only, the disposeConnection
           // function carries out disposal (or caching etc).
           disposeConnection(connection, connectionEstablished);
        }
    }
