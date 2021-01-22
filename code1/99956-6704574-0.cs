    // if windows 2003
    if (Environment.OSVersion.Version.Major == 5 &&
    Environment.OSVersion.Version.Minor == 2)
    {
      DirectoryEntry folderRoot = new DirectoryEntry("IIS://localhost/W3SVC");
      folderRoot.Invoke("EnableWebServiceExtension", "ASP.NET v2.0.50727");
    }
