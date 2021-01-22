    Server svr = new Server();
             
    res.Database = "SMO";
    res.Action = RestoreActionType.Database;
    res.Devices.AddDevice(@"C:\SMOTest.bak", DeviceType.File);
    res.PercentCompleteNotification = 10;
    res.ReplaceDatabase = true;
    res.PercentComplete += new PercentCompleteEventHandler(ProgressEventHandler);
    res.SqlRestore(srv);
