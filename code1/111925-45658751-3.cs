    // Setup session options
    SessionOptions sessionOptions = new SessionOptions
    {
        Protocol = Protocol.Sftp,
        HostName = "example.com",
        UserName = "user",
        Password = "mypassword",
        SshHostKeyFingerprint = "ssh-rsa 2048 xxxxxxxxxxx...="
    };
    using (Session session = new Session())
    {
        // Connect
        session.Open(sessionOptions);
        // Upload files
        session.PutFiles(@"d:\toupload\*", "/home/user/").Check();
    }
