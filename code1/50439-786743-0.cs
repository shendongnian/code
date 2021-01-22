    static void Main(string[] args)
    {
        AddHostHeader(1, "127.0.0.1", 8080, "fred");
        AddHostHeader(1, null, 8081, null);
    }
    
    static void AddHostHeader(int? websiteID, string ipAddress, int? port, string hostname)
    {
        using (var directoryEntry = new DirectoryEntry("IIS://localhost/w3svc/" + websiteID.ToString()))
        {
            var bindings = directoryEntry.Properties["ServerBindings"];
            var header = string.Format("{0}:{1}:{2}", ipAddress, port, hostname);
    
            if (bindings.Contains(header))
                throw new InvalidOperationException("Host Header already exists!");
    
            bindings.Add(header);
            directoryEntry.CommitChanges();
        }
    }
