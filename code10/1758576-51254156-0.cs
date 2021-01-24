    QBSessionManager SessionManager = null;
    try
    {
        SessionManager = new QBSessionManager();
        SessionManager.OpenConnection2("UniqueAppID", "Lumber Management System", ENConnectionType.ctLocalQBD);
        SessionManager.BeginSession("C:\\Users\\Jerry\\Documents\\QuickBooks\\Company Files\\MRJ Tecnology, LLC.qbw", ENOpenMode.omSingleUser);
                    
        // CODE TO SEND TO QB GOES HERE
    }
    catch(Exception ex)
    {
        MessageBox.Show("Error opening QB:" + ex.ToString());
    }
    finally
    {
        if(SessionManager != null)
        {
            SessionManager.EndSession();
            SessionManager.CloseConnection();
        }
    }
