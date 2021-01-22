    ServerConnection conn = new ServerConnection("rune\\sql2008");
    Server server = new Server(conn);
    
    Database newdb = new Database(server, "new database");
    newdb.Create();
    
    Transfer transfer = new Transfer(server.Databases["source database"]);
    transfer.CopyAllObjects = true;
    transfer.CopyAllUsers = true;
    transfer.Options.WithDependencies = true;
    transfer.DestinationDatabase = newdb.Name;
    transfer.DestinationServer = server.Name;
    transfer.DestinationLoginSecure = true;
    transfer.CopySchema = true;
    transfer.CopyData = true;
    transfer.Options.ContinueScriptingOnError = true;
    transfer.TransferData();
