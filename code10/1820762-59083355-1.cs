using (SqlConnection connection = new SqlConnection(connectionString))
{
    var server = new Server(new ServerConnection(connection));
    Database targetDb = server.Databases["TargetDbName"];
    
    // Make sure your user has ALTER ANY CONNECTION rights for this
    // not needed if you can be sure db is not in use
    server.KillAllProcesses(targetDb.Name);
    targetDb.SetOffline();
    Restore restoreDB = new Restore();
    restoreDB.Database = targetDb.Name;
    restoreDB.Action = RestoreActionType.Database;
    restoreDB.ReplaceDatabase = true;
    // Restore the full backup first
    var fullBackupDevice = new BackupDeviceItem("fullBackupFile.bak", DeviceType.File);
    restoreDB.Devices.Add(fullBackupDevice);
    restoreDB.NoRecovery = true;
    restoreDB.SqlRestore(server);
    restoreDB.Devices.Remove(fullBackupDevice);
    // Get the first taken transaction log file
    var firstTransactionBackupDevice = new BackupDeviceItem("firstTrnFile.trn", DeviceType.File);
    restoreDB.Devices.Add(firstTransactionBackupDevice);
    restoreDB.SqlRestore(server);
    restoreDB.Devices.Remove(firstTransactionBackupDevice);
    // Get the second taken transaction log file
    var secondTransactionBackupDevice = new BackupDeviceItem("secondTrnFile.trn", DeviceType.File);
    restoreDB.Devices.Add(secondTransactionBackupDevice);
    // You have to set this flag to false before the last file you will restore
    // to return the db to the normal state
    restoreDB.NoRecovery = false;
    restoreDB.SqlRestore(server);
    restoreDB.Devices.Remove(secondTransactionBackupDevice);
    targetDb.SetOnline();
    server.Refresh();
}
I know your question is a bit older and you've probably found a solution already, but hopefully this helps to someone else.
