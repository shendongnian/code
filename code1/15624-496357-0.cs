    using System.DirectoryServices;
    
    ...
    void Recycle(string appPool)
    {
        string appPoolPath = "IIS://localhost/W3SVC/AppPools/" + appPool;
        using (DirectoryEntry appPoolEntry = new DirectoryEntry(appPoolPath))
        {
                appPoolEntry.Invoke("Recycle", null);
                appPoolEntry.Close();
        }
    }
