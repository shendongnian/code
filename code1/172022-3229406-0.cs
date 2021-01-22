    // If IIS7
    // Add reference to Microsoft.Web.Administration in 
    // C:\windows\system32\inetsrv
    
    using Microsoft.Web.Administration;
    ...
    int iisNumber = 2;
    
    using(ServerManager serverManager = new ServerManager())
    {
      var site = serverManager.Sites.Where(s => s.Id == iisNumber).Single();
      var applicationRoot = 
               site.Applications.Where(a => a.Path == "/").Single();
      var virtualRoot = 
               applicationRoot.VirtualDirectories.Where(v => v.Path == "/").Single();
      Console.WriteLine(virtualRoot.PhysicalPath);
    }
