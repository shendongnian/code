    // If IIS6
    // Add reference to System.DirectoryServices on .NET add ref tab
    
    using System.DirectoryServices;
    ...
    int iisNumber = 2;
    string metabasePath = String.Format("IIS://Localhost/W3SVC/{0}/root", iisNumber);
    using(DirectoryEntry de = new DirectoryEntry(metabasePath))
    {
      Console.WriteLine(de.Properties["Path"].Value);
    }
