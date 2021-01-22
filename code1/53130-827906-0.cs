    static void Main(string[] args)
    {
        Program shell = new Program();
        // get connection strings from command line arguments
        string sourceConnectionString = shell.getConnectionString(args);
        string destinationConnectionString = shell.getConnectionString(args);
        // call non-static methods that use
        shell.setUpConnections(sourceConnectionString, destinationConnectionString);
        try
        {
          shell.doDatabaseWork();
        }
        finally
        {
          if(sourceConnection != null)
            sourceConnection.Dispose();
          if(destinationConnection != null)
            destinationConnection.Dispose();
        }
    }
