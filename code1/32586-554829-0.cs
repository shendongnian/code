       //----------------------------------------------------------------------------------------
        // Function: GetLastBackupTime
        //
        // Input
        //    sqlConnection          - An open SQLConnection to the target SQL Server
        //    DatabaseName           - Name of the database which you are interested in
        //    fullDatabaseBackupOnly - Do you want only the time of the last full backup
        //
        // Output
        //    DateTime               - DateTime.MinValue indicates no backup exists
        //                             otherwise it returns the last backup time
        //---------------------------------------------------------------------------------------
    
    DateTime GetLastBackupTime( SqlConnection sqlConnection, 
                                string        databaseName, 
                                bool          fullDatabaseBackupOnly )
    {
        DateTime lastBackupTime = DateTime.MinValue;  
    
        string sqlTemplate = "SELECT TOP 1 backup_finish_date " +
                             "FROM msdb.dbo.backupset " + 
                             "WHERE database_name='{0}' {1} "
                             "ORDER BY backup_finish_date DESC";
    
        string sql = String.Format( sqlTemplate,
                                    databaseName,
                                    (fullDatabaseBackupOnly ) ? " AND type='D' " : "" );
    
        // open connection
        using (SqlCommand cmd = new SqlCommand(sql, sqlConnection, 
        {
           object retValue = _Command.ExecuteScalar();
    
           if ( retValue != null ) lastBackupTime = (DateTime)retValue;
        } 
    
        return lastBackupTime;
    }
