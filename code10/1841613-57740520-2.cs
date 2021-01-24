    public static int WinSCPListDirectory()
    {
        try
        {
            var sessionOptions = new SessionOptions
            {
                Protocol = Protocol.Sftp,
                HostName = "xxx.xxx.xxx.xxx",
                UserName = "username",
                Password = "password",
                SshHostKeyFingerprint = "ssh-rsa 2048 xx:xx:xx:xx:xx:xx:xx:xx:xx:xx:xx:xx:xx:xx:xx:xx",
                GiveUpSecurityAndAcceptAnySshHostKey = true
            };
    
            using (var session = new Session())
            {
                session.Open(sessionOptions);
    
                var directory = session.ListDirectory("/var/www");
    
                foreach (RemoteFileInfo fileInfo in directory.Files)
                {
                    Console.WriteLine(
                        "{0} with size {1}, permissions {2} and last modification at {3}",
                        fileInfo.Name, fileInfo.Length, fileInfo.FilePermissions,
                        fileInfo.LastWriteTime);
                }
            }
    
            return 0;
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: {0}", e);
            return 1;
        }
    }
