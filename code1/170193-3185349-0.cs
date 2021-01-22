    using Microsoft.Web.Administration;
.
.
.
      ServerManager mgr = new ServerManager();
      foreach (Site mySite in mgr.Sites)
        Response.Write("Site : " + mySite.Name + " -- path: " + mySite.Applications["/"].VirtualDirectories["/"].PhysicalPath + "<br />");              
    
