    // Setup session options
    SessionOptions sessionOptions = new SessionOptions
    {
        Protocol = Protocol.Ftp,
        HostName = "example.com",
        UserName = "user",
        Password = "password",
    };
    using (Session session = new Session())
    {
        // Connect
        session.Open(sessionOptions);
        List<string> prevFiles = null;
        while (true)
        {
            // Collect file list
            List<string> files =
                session.EnumerateRemoteFiles(
                    "/remote/path", "*.*", EnumerationOptions.AllDirectories)
                .Select(fileInfo => fileInfo.FullName)
                .ToList();
            if (prevFiles == null)
            {
                // In the first round, just print number of files found
                Console.WriteLine("Found {0} files", files.Count);
            }
            else
            {
                // Then look for differences against the previous list
                IEnumerable<string> added = files.Except(prevFiles);
                if (added.Any())
                {
                    Console.WriteLine("Added files:");
                    foreach (string path in added)
                    {
                        Console.WriteLine(path);
                    }
                }
                IEnumerable<string> removed = prevFiles.Except(files);
                if (removed.Any())
                {
                    Console.WriteLine("Removed files:");
                    foreach (string path in removed)
                    {
                        Console.WriteLine(path);
                    }
                }
            }
            prevFiles = files;
            Console.WriteLine("Sleeping 10s...");
            Thread.Sleep(10000);
        }
    }
