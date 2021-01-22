    public void BackupDatabase(SqlConnectionStringBuilder csb, string destinationPath)
    {
        ServerConnection connection = new ServerConnection(csb.DataSource, csb.UserID, csb.Password);
        Server sqlServer = new Server(connection);
        Backup bkpDatabase = new Backup();
        bkpDatabase.Action = BackupActionType.Database;
        bkpDatabase.Database = csb.InitialCatalog;
        BackupDeviceItem bkpDevice = new BackupDeviceItem(destinationPath, DeviceType.File);
        bkpDatabase.Devices.Add(bkpDevice);
        bkpDatabase.SqlBackup(sqlServer);
        connection.Disconnect();
        
    }
    public void RestoreDatabase(String databaseName, String backUpFile, String serverName, String userName, String password)
    {
        ServerConnection connection = new ServerConnection(serverName, userName, password);
        Server sqlServer = new Server(connection);
        Restore rstDatabase = new Restore();
        rstDatabase.Action = RestoreActionType.Database;
        rstDatabase.Database = databaseName;
        BackupDeviceItem bkpDevice = new BackupDeviceItem(backUpFile, DeviceType.File);
        rstDatabase.Devices.Add(bkpDevice);
        rstDatabase.ReplaceDatabase = true;
        rstDatabase.SqlRestore(sqlServer);
    }
