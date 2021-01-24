    private static void AddAccessToCertificate(X509Certificate2 cert, string user)
            {
                RSACryptoServiceProvider rsa = cert.PrivateKey as RSACryptoServiceProvider;
    
                if (rsa != null)
                {
                    string keyfilepath =
                        FindKeyLocation(rsa.CspKeyContainerInfo.UniqueKeyContainerName);
    
                    FileInfo file = new FileInfo(keyfilepath + "\\" +
                        rsa.CspKeyContainerInfo.UniqueKeyContainerName);
    
                    FileSecurity fs = file.GetAccessControl();
    
                    NTAccount account = new NTAccount(user);
                    fs.AddAccessRule(new FileSystemAccessRule(account,
                    FileSystemRights.FullControl, AccessControlType.Allow));
    
                    file.SetAccessControl(fs);
                }
            }
