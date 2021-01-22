    // Set up session options
    SessionOptions sessionOptions = new SessionOptions
    {
        Protocol = Protocol.Ftp,
        UserName = "username",
        Password = "password",
        FtpSecure = FtpSecure.Implicit,
    };
    
    using (Session session = new Session())
    {
        // Connect
        session.Open(sessionOptions);
    
        // Your code
    }
