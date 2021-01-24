    public string RemoveFile(string fileName,string databaseName)
    {
       Server srv = new Server(servConn);
        Database database = srv.Databases[databaseName];
        if (database != null)
        {
            var file = LoadFiles(databaseName).Where(a => a.Name == fileName);
    
            if (!file.Any())
            {
                SqlServerDisconnect();
                return "File  Doesn't  Exist.kindly Enter Right File Name";
            }
            else
            {
                DataFile fileToRemove = file.FirstOrDefault();
                fileToRemove.Drop();
                database.Alter();
                return "File  Removed Successfully";
            }
        }
    }
