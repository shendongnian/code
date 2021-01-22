    // (replace "part_of_group_name" with some partial group name existing in your AD)
    var groupNameContains = "part_of_group_name";
    var identity = WindowsIdentity.GetCurrent().User;
    var allDomains = Forest.GetCurrentForest().Domains.Cast<Domain>();
    var allSearcher = allDomains.Select(domain =>
    {
        var searcher = new DirectorySearcher(new DirectoryEntry("LDAP://" + domain.Name));
        // Apply some filter to focus on only some specfic objects
        searcher.Filter = String.Format("(&(objectClass=group)(name=*{0}*))", groupNameContains);
        return searcher;
    });
    var directoryEntriesFound = allSearcher
        .SelectMany(searcher => searcher.FindAll()
            .Cast<SearchResult>()
            .Select(result => result.GetDirectoryEntry()));
    var allowedTo = directoryEntriesFound.Select(entry =>
        {
            using (entry)
            {
                entry.RefreshCache(new string[] { "allowedAttributesEffective" });
                var rights = entry.Properties["allowedAttributesEffective"].Value == null ? "read only" : "write";
                return new { Name = entry.Name, AllowedTo = rights };
            }
        });
    foreach (var item in allowedTo)
    {
        var message = String.Format("Name = {0}, AllowedTo = {1}", item.Name, item.AllowedTo);
        Debug.Print(message);
    }
