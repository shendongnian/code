    try
    {		
        SqlConnection sqlConnection = new SqlConnection(connectionString);
    	sqlConnection.Open();
    
    	string serverVersion = sqlConnection.ServerVersion;
    	string[] serverVersionDetails = serverVersion.Split( new string[] {"."}, StringSplitOptions.None);
    
    	int versionNumber = int.Parse(serverVersionDetails[0]);
    
    	switch (versionNumber)
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
    			MessageBox.Show(string.Format("SQL Server {0}", versionNumber.ToString()));  
    			break;  
    	}
    }
    catch (Exception ex)
    {
        MessageBox.Show(string.Format("Unable to connect to server due to exception: {1}", ex.Message),
    	    "Invalid Connection!", MessageBoxButtons.OK, MessageBoxIcon.Error);
    
    }
    finally
    {
    	sqlConnection.Close();
    }
