    /// <summary>
    /// Returns a list of all the Application Pools configured
    /// </summary>
    /// <returns></returns>
    public ApplicationPool[] GetApplicationPools()
    {           
        if (ServerType != WebServerTypes.IIS6 && ServerType != WebServerTypes.IIS7)
            return null;
     
        DirectoryEntry root = this.GetDirectoryEntry("IIS://" + this.DomainName + "/W3SVC/AppPools");
          if (root == null)
                return null;
     
        List<ApplicationPool> Pools = new List<ApplicationPool>();
     
        foreach (DirectoryEntry Entry in root.Children)
        {
            PropertyCollection Properties = Entry.Properties;
     
            ApplicationPool Pool = new ApplicationPool();
            Pool.Name = Entry.Name;
           
            Pools.Add(Pool);
        }
     
        return Pools.ToArray();
    }
     
    /// <summary>
    /// Create a new Application Pool and return an instance of the entry
    /// </summary>
    /// <param name="AppPoolName"></param>
    /// <returns></returns>
    public DirectoryEntry CreateApplicationPool(string AppPoolName)
    {
        if (this.ServerType != WebServerTypes.IIS6 && this.ServerType != WebServerTypes.IIS7)
            return null;
     
        DirectoryEntry root = this.GetDirectoryEntry("IIS://" + this.DomainName + "/W3SVC/AppPools");
        if (root == null)
            return null;
     
        DirectoryEntry AppPool = root.Invoke("Create", "IIsApplicationPool", AppPoolName) as DirectoryEntry;           
        AppPool.CommitChanges();
     
        return AppPool;
    }
      
    /// <summary>
    /// Returns an instance of an Application Pool
    /// </summary>
    /// <param name="AppPoolName"></param>
    /// <returns></returns>
    public DirectoryEntry GetApplicationPool(string AppPoolName)
    {
        DirectoryEntry root = this.GetDirectoryEntry("IIS://" + this.DomainName + "/W3SVC/AppPools/" + AppPoolName);
        return root;
    }
     
    /// <summary>
    /// Retrieves an Adsi Node by its path. Abstracted for error handling
    /// </summary>
    /// <param name="Path">the ADSI path to retrieve: IIS://localhost/w3svc/root</param>
    /// <returns>node or null</returns>
    private DirectoryEntry GetDirectoryEntry(string Path)
    {
     
        DirectoryEntry root = null;
        try
        {
            root = new DirectoryEntry(Path);
        }
        catch
        {
            this.SetError("Couldn't access node");
            return null;
        }
        if (root == null)
        {
            this.SetError("Couldn't access node");
            return null;
        }
        return root;
    }
