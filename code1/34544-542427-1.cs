    // Connect to the server
    Server server = new Server(".");
    
    // Get the database to copy
    Database db = server.Databases["MyDatabase"];
        
    // Set options
    Transfer transfer = new Transfer(db);
    transfer.CopyAllObjects = true;
    transfer.DropDestinationObjectsFirst = true;
    transfer.CopySchema = true;
    transfer.CopyData = true;
    transfer.DestinationServer = ".";
    transfer.DestinationDatabase = "MyBackupDatabase";
    transfer.Options.IncludeIfNotExists = true;
    
    
    // Transfer Schema and Data
    transfer.TransferData();
       
    
