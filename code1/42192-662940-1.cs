    public int GetWebSiteId(string serverName, string websiteName)
    {
      int result = -1;
    
      DirectoryEntry w3svc = new DirectoryEntry(
                          string.Format("IIS://{0}/w3svc", serverName));
    
      foreach (DirectoryEntry site in w3svc.Children)
      {
        if (site.Properties["ServerComment"] != null)
        {
          if (site.Properties["ServerComment"].Value != null)
          {
            if (string.Compare(site.Properties["ServerComment"].Value.ToString(), 
                                 websiteName, false) == 0)
            {
                result = site.Name;
                break;
            }
          }
        }
      }
      
      return result;
    }
