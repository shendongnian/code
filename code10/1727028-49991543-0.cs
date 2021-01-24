    using (var context = new PrincipalContext(ContextType.Domain, domainName))
    {
        // init vars
        var up = new UserPrincipal(context);
        var ps = new PrincipalSearcher(up);
        var allUsers = ps.FindAll().ToList();
        var users = allUsers.Where(x => 
            x.DisplayName == groupUser.Item3 + ", " + groupUser.Item2).ToList();
        
        if (users.Count > 1) {
            throw new Exception("More than one account found for: " + groupUser.Item3 + ", " + groupUser.Item2)
        }
        
        var user2 = users.FirstOrDefault();
    }
