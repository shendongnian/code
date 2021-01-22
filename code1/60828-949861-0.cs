    try
    {
       SqlConnection conn = new SqlConnection(connectionString);
       Server srv = new Server(new ServerConnection(conn));
       
       // Check if we're using 2005 or higher
       if (srv.Information.Version.Major >= 9)
       {
       	
       }
       else
       {
          # Sql Server 2000
       }
    }
    catch (ConnectionFailureException)
    {
    	MessageBox.Show("Unable to connect to server", "Invalid Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
