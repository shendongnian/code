            try
            {
                // Setup session options
                SessionOptions sessionOptions = new SessionOptions
                {
                    Protocol = Protocol.Ftp,
                    FtpSecure = FtpSecure.None,
                    HostName = "10.101.10.10",
                    UserName = "user",
                    PortNumber = 21,
                    Password = "passcode",  
                };
                using (WinSCP.Session session = new WinSCP.Session())
                {
                    // Connect
                    session.Open(sessionOptions);
                    var files = session.EnumerateRemoteFiles("/path/", "test*", WinSCP.EnumerationOptions.None);
                    var directory = session.ListDirectory("/path/");
                    foreach (var dir in files) {
                        Console.WriteLine(dir);
                    }
                        // Upload files
                    TransferOptions transferOptions = new TransferOptions();
                    transferOptions.TransferMode = TransferMode.Binary;
                    TransferOperationResult transferResult;
                    transferResult =
                        session.GetFiles("/path/test*", @"D:\", false, transferOptions);
                    // Throw on any error
                    transferResult.Check();
                    // Print results
                    foreach (TransferEventArgs transfer in transferResult.Transfers)
                    {
                        Console.WriteLine("Download of {0} succeeded", transfer.FileName);
                    }
                }
            }
            catch (Exception e)
            {
                Console.Write
