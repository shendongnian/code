    // Setup session options
    SessionOptions sessionOptions = new SessionOptions
    {
        Protocol = Protocol.Ftp,
        HostName = "example.com",
        UserName = "user",
        Password = "mypassword",
    };
    using (Session session = new Session())
    {
        // Connect
        session.Open(sessionOptions);
        // Download files
        session.GetFiles("/home/user/*", @"d:\download\").Check();
    } 
