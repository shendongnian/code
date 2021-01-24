    try
            {
                // Setup session options
                SessionOptions sessionOptions = new SessionOptions
                {
                    Protocol = Protocol.Ftp,
                    HostName = @"xx.xx.x.x",
                    UserName = "xxxx",
                    Password = "xxxxxx",
                    PortNumber = xxxx,
                    FtpSecure = FtpSecure.Implicit, //Encryption protocol
                    GiveUpSecurityAndAcceptAnyTlsHostCertificate = true // Accepts any certificate
    `
                };
                using (Session session = new Session())
                {
                    // Connect
                    session.Open(sessionOptions);
                    // Upload files
                    TransferOptions transferOptions = new TransferOptions();
                    transferOptions.TransferMode = TransferMode.Binary;
                    TransferOperationResult transferResult;
                    transferResult =
    //Copy's Existing file to Connected server and delets the old one. change by replace "true" with "false".
                        session.PutFiles(ExistingPath, "/ScheduleJobs/" + RemotePath, true, transferOptions);
                    // Throw on any error
                    transferResult.Check();
                    // Print results
                    foreach (TransferEventArgs transfer in transferResult.Transfers)
                    {
                        Console.WriteLine("Upload of {0} succeeded", transfer.FileName);
                        Console.ReadLine();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e);
            }
        }
