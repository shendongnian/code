    public IList<User> ActiveUsersInRole(Role role)
    { 
        var users = _userRep.FindAll(); // IQueryable<User>() - delayed execution;
        var activeUsersInRole = from users u where u.IsActive = true && u.Role.Contains(role);
        // I can't remember any linq and i'm type pseudocode, but
        // again the point is that the service is presenting a simple
        // interface and delegating responsibility to
        // the repository with it's simple methods.
        return activeUsersInRole;
    }
