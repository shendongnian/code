    // Set up session options
    SessionOptions sessionOptions = new SessionOptions
    {
        Protocol = Protocol.Ftp,
        HostName = "10.0.0.4",
        FtpMode = FtpMode.Active,
    };
    
    using (Session session = new Session())
    {
        session.AddRawConfiguration(@"Interface\ExternalIpAddress", "your public IP address");
        // Connect
        session.Open(sessionOptions);
    
        // Upload
        session.PutFiles(@"C:\local\path\file.txt", "/upload/mytest.txt").Check();
    }
