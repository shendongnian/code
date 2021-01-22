    private static bool CheckDatabaseExists(SqlConnection tmpConn, string databaseName)
    {
        string sqlCreateDBQuery;
        bool result = false;
    
        try
        {
            tmpConn = new SqlConnection("server=(local)\\SQLEXPRESS;Trusted_Connection=yes");
        
            sqlCreateDBQuery = string.Format("SELECT database_id FROM sys.databases WHERE Name 
            = '{0}'", databaseName);
        
            using (tmpConn)
            {
                using (SqlCommand sqlCmd = new SqlCommand(sqlCreateDBQuery, tmpConn))
                {
                    tmpConn.Open();
                    object resultObj = sqlCmd.ExecuteScalar();
                    int databaseID = 0;    
                    if (resultObj != null)
                    {
                        int.TryParse(resultObj.ToString(), out databaseID);
                    }
                    tmpConn.Close();
                    
                    result = (databaseID > 0);
                }
            }
        } 
        catch (Exception ex)
        { 
            result = false;
        }
        
        return result;
    }
