    public static IEnumerable<Guid> GetUserMemberOf(DirectoryEntry de) {
        var groups = new List<Guid>();
    
        //retrieve only the memberOf attribute from the user
        de.RefreshCache(new[] {"memberOf"});
    
        while (true) {
            var memberOf = de.Properties["memberOf"];
            foreach (string group in memberOf) {
                var groupDe = new DirectoryEntry($"LDAP://{group.Replace("/", "\\/")}");
                groupDe.RefreshCache(new[] {"objectGUID"});
                groups.Add(new Guid((byte[]) groupDe.Properties["objectGUID"].Value));
            }
    
            //AD only gives us 1000 or 1500 at a time (depending on the server version)
            //so if we've hit that, go see if there are more
            if (memberOf.Count != 1500 && memberOf.Count != 1000) break;
    
            try {
                de.RefreshCache(new[] {$"memberOf;range={groups.Count}-*"});
            } catch (COMException e) {
                if (e.ErrorCode == unchecked((int) 0x80072020)) break; //no more results
    
                throw;
            }
        }
        return groups;
    }
