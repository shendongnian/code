    using Dex = Microsoft.Dexterity.Applications;
            internal static SqlConnection conn = new SqlConnection();
            internal static SqlConnection GetOpenGPConnection()
            {
                try
                {
    		//Call Startup
    		int resp = GPConnection.Startup();
    		// Create the connection object
    		Microsoft.Dexterity.GPConnection GPConn = new GPConnection();
    		//  Initialize
    		GPConn.Init("MyVSTDCompanyid", "myVSTDGPAuthCode");  // get this from Microsoft GP Dev Tools Support
    		conn.ConnectionString = String.Format("Database = {0}", Dex.Dynamics.Globals.IntercompanyId.Value);
    		GPConn.Connect(conn, Dex.Dynamics.Globals.SqlDataSourceName, Dex.Dynamics.Globals.UserId, Dex.Dynamics.Globals.SqlPassword);
    		if ((GPConn.ReturnCode & (int)GPConnection.ReturnCodeFlags.SuccessfulLogin) == (int)GPConnection.ReturnCodeFlags.SuccessfulLogin)
    		{
    		return conn;
    		}
    		else
    		{//...  user authenticaltion failed - backup plan?  fallback to windows auth?  
    		return null
    		}
    	
                }
                catch (Exception ex)
                {
                	// your catch handling mechanism
                }
            }
