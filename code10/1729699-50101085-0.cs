    public override void BeforeRun()
    {
        var fs = new Sys.FileSystem.CosmosVFS();
        Sys.FileSystem.VFS.VFSManager.RegisterVFS(fs);
    }
    public override void Run()
    {
        var usersFile = @"0:\users.dat";
        if (!File.Exists(usersFile))
        {
            File.Create(usersFile);
        }
        // now you can read or write to the file
        // example read methods: File.ReadAllText, File.ReadAllLines, File.ReadAllBytes
        // example write methods: File.WriteAllText, File.WriteAllLines, File.WriteAllBytes
    }
