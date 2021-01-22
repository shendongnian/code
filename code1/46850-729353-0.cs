    using Microsoft.SqlServer.Management.Smo;
    
    var bdi = new BackupDeviceItem(/* your path inlcuding desired file */);
    var backup = new Backup
    {
    	Database = /* name of the database */,
    	Initialize = true
    };
    
    backup.Devices.Add(bdi);
    
    var server = new Server(this.SqlServer);
    
    try
    {
    	backup.SqlBackup(server);
    }
    catch (Exception ex)
    {
    	// * log or sth
    }
