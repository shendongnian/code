using (SqlConnection connection = new SqlConnection(connectionString))
{
    var server = new Server(new ServerConnection(connection));
    Database targetDb= server.Databases["targetDb"];
    server.KillAllProcesses(targetDb.Name);
    Restore restoreDB = new Restore();
    restoreDB.Database = targetDb.Name;
    restoreDB.Action = RestoreActionType.Database;
    restoreDB.ReplaceDatabase = true;
    // Restore the full backup first
    var fullBackupDevice = new BackupDeviceItem(fullBackupFilePath, DeviceType.File);
    restoreDB.Devices.Add(fullBackupDevice);
    restoreDB.NoRecovery = true;
    restoreDB.SqlRestore(server);
    restoreDB.Devices.Remove(fullBackupDevice);
    // Get the related transaction log file
    var transactionBackupDevice = new BackupDeviceItem(trnFileFullPath, DeviceType.File);
    restoreDB.Devices.Add(transactionBackupDevice);
    // You have to set this flag to false before the last file you will restore to return the db to the normal state
    restoreDB.NoRecovery = false;
    restoreDB.SqlRestore(server);
    restoreDB.Devices.Remove(transactionBackupDevice);
    targetDb.SetOnline();
    server.Refresh();
}
I know your question is a bit older and you've probably found a solution already, but hopefully this helps to someone else.
