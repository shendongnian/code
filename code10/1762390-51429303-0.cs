                    if (!smoServer.Credentials.Contains(CredentialName))
                    {
                        Credential cr = new Credential(smoServer, CredentialName);
                        cr.Create("SHARED ACCESS SIGNATURE", AzureDataModel.SharedAccessKey);
                    }
    
                    Restore restoreDB = new Restore();
                    restoreDB.Action = RestoreActionType.Database;
                    restoreDB.Database = databaseName;
                    BackupDeviceItem deviceItem = new BackupDeviceItem(backUpFile, DeviceType.Url);
                    restoreDB.Devices.Add(deviceItem);
                    restoreDB.ReplaceDatabase = true;
                    if (!smoServer.Databases.Contains(databaseName)) {
                        Database db = new Database(smoServer, databaseName);
                        db.Create();
                    }
    
                    RelocateFile DataFile = new RelocateFile();
                    string MDF = restoreDB.ReadFileList(smoServer).Rows[0][1].ToString();
                    DataFile.LogicalFileName = restoreDB.ReadFileList(smoServer).Rows[0][0].ToString();
                    DataFile.PhysicalFileName = smoServer.Databases[databaseName].FileGroups[0].Files[0].FileName;
                    
                    RelocateFile LogFile = new RelocateFile();
                    string LDF = restoreDB.ReadFileList(smoServer).Rows[1][1].ToString();
                    LogFile.LogicalFileName = restoreDB.ReadFileList(smoServer).Rows[1][0].ToString();
                    LogFile.PhysicalFileName = smoServer.Databases[databaseName].LogFiles[0].FileName;
    
                    restoreDB.RelocateFiles.Add(DataFile);
                    restoreDB.RelocateFiles.Add(LogFile);
                    restoreDB.NoRecovery = false;
                    restoreDB.PercentComplete += new PercentCompleteEventHandler(rstDatabase_PercentComplete);
                    restoreDB.Complete += new ServerMessageEventHandler(rstDatabase_Complete);
                    restoreDB.SqlRestore(smoServer);
