            string absPathSource = downloadLocation + file;
            string destination = "/root/folder"; //this basically is your FTP path
        // Setup session options
            SessionOptions sessionOptions = new SessionOptions
            {
                Protocol = Protocol.Sftp,
                HostName = ConfigurationManager.AppSettings["scpurl"],
                UserName = ConfigurationManager.AppSettings["scpuser"],
                Password = ConfigurationManager.AppSettings["scppass"].Trim(),
                SshHostKeyFingerprint = ConfigurationManager.AppSettings["scprsa"].Trim()
            };
            using (Session session = new Session())
            {
                //disable version checking
                session.DisableVersionCheck = true;
                // Connect
                session.Open(sessionOptions);
                // Upload files
                TransferOptions transferOptions = new TransferOptions();
                transferOptions.TransferMode = TransferMode.Binary;
                TransferOperationResult transferResult;
                transferResult = session.PutFiles(absPathSource, destination, false, transferOptions);
                // Throw on any error
                transferResult.Check();
                // Print results
                foreach (TransferEventArgs transfer in transferResult.Transfers)
                {
                    //Console.WriteLine("Upload of {0} succeeded", transfer.FileName);
                }
            }
