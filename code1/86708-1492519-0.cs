    private static void AddAccessToCertificate(X509Certificate2 cert)
    {
      RSACryptoServiceProvider rsa = cert.PrivateKey as RSACryptoServiceProvider;
      if (rsa == null) return;
    
      string keyfilepath = FindKeyLocation(rsa.CspKeyContainerInfo.UniqueKeyContainerName);
    
      FileInfo file = new FileInfo(System.IO.Path.Combine(keyfilepath, rsa.CspKeyContainerInfo.UniqueKeyContainerName));
    
      FileSecurity fs = file.GetAccessControl();
    
      SecurityIdentifier sid = new SecurityIdentifier(WellKnownSidType.BuiltinUsersSid, null);
      fs.AddAccessRule(new FileSystemAccessRule(sid, FileSystemRights.Read, AccessControlType.Allow));
      file.SetAccessControl(fs);
    }
    
    private static string FindKeyLocation(string keyFileName)
    {
      string pathCommAppData = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), @"Microsoft\Crypto\RSA\MachineKeys");
      string[] textArray = Directory.GetFiles(pathCommAppData, keyFileName);
      if (textArray.Length > 0) return pathCommAppData;
    
      string pathAppData = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"Microsoft\Crypto\RSA\");
      textArray = Directory.GetDirectories(pathAppData);
      if (textArray.Length > 0)
      {
    	foreach (string str in textArray)
    	{
    	  textArray = Directory.GetFiles(str, keyFileName);
    	  if (textArray.Length != 0) return str;
    	}
      }
      return "Private key exists but is not accessible";
    }
