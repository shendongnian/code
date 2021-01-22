    // Setup session options
    SessionOptions sessionOptions = new SessionOptions
    {
        Protocol = Protocol.Ftp,
        HostName = "example.com",
        UserName = "user",
        Password = "mypassword",
    };
    // Configure proxy
    sessionOptions.AddRawSettings("ProxyMethod", "3");
    sessionOptions.AddRawSettings("ProxyHost", "proxy");
    using (Session session = new Session())
    {
        // Connect
        session.Open(sessionOptions);
        // Upload file
        string localFilePath = @"C:\path\file.txt";
        string pathUpload = "/file.txt";
        session.PutFiles(localFilePath, pathUpload).Check();
    }
