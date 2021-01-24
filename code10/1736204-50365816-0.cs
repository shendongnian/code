    private (bool bRet, int nRet) CheckDatabase(string databaseName)
    {
        string connString = "Server=localhost\\SQLEXPRESS;Integrated 
        Security=SSPI;database=master";
        string cmdText = "select * from master.dbo.sysdatabases where name=\'" + databaseName + "\'";
        bool bRet;
        int nRet;
        using (SqlConnection sqlConnection = new SqlConnection(connString))
        {
            sqlConnection.Open();
            using (SqlCommand sqlCmd = new SqlCommand(cmdText, sqlConnection))
            {
                nRet = sqlCmd.ExecuteNonQuery();
                bRet = !(Ret <= 0)
            }
        }
        return (bRet, nRet);
    }
