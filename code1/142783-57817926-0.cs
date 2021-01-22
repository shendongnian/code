     public List<String> GetNetworkHostNames()
     {
            using (var directoryEntry = new DirectoryEntry("WinNT:"))
            {
                return directoryEntry
                         .Children
                         .Cast<DirectoryEntry>()
                         .SelectMany(x=>x.Children.Cast<DirectoryEntry>())
                         .Where(c => c.SchemaClassName == "Computer")
                         .Select(c => c.Name)
                         .ToList();
            }
     }
    
