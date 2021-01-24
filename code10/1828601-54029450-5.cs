    // Set up session options
    SessionOptions sessionOptions = new SessionOptions
    {
        Protocol = Protocol.Sftp,
        HostName = baseHost,
        UserName = user,
        SshHostKeyFingerprint = ...,
        SshPrivateKeyPath = keyLocation,
        PrivateKeyPassphrase = pkpassword,
    };
    
    using (Session session = new Session())
    {
        // Connect
        session.Open(sessionOptions);
    
        // Your code
    }
