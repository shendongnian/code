    SessionOptions sessionOptions = new SessionOptions {
        Protocol = Protocol.Ftp,
        HostName = "ftp.example.com",
        UserName = "username",
        Password = "password",
    };
    Session session = new Session();
    session.Open(sessionOptions);
    if (session.FileExists("/remote/path/file.txt"))
    {
        Console.WriteLine("Exists");
    }
    else
    {
        Console.WriteLine("Does not exist");
    }
