    try
    {
        SqlConnection sqlConnection = new SqlConnection(connectionString);
        Microsoft.SqlServer.Management.Smo.Server server = new Microsoft.SqlServer.Management.Smo.Server(new Microsoft.SqlServer.Management.Common.ServerConnection(sqlConnection));
    
    	switch (server.Information.Version.Major)
        {
    	  case 8:
    	    MessageBox.Show("SQL Server 2000");
    	    break;
    	  case 9:
    	    MessageBox.Show("SQL Server 2005");
    	    break;
    	  case 10:
    	    MessageBox.Show("SQL Server 2008");
    				break;
    	  default:
    	    MessageBox.Show(string.Format("SQL Server {0}", server.Information.Version.Major.ToString())); 
    	    break;   
        }
    }
    catch (Microsoft.SqlServer.Management.Common.ConnectionFailureException)
    {
        MessageBox.Show("Unable to connect to server",
    	    "Invalid Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
    
    }
