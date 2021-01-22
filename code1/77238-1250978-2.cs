    static void EnforceRole(string role)
    {
        if (string.IsNullOrEmpty(role)) { return; } // assume anon OK
        IPrincipal principal = Thread.CurrentPrincipal;
        if (principal == null || !principal.IsInRole(role))
        {
            throw new SecurityException("Access denied to role: " + role);
        }
    }
    public static User GetUser(string id)
    {
        User user = Repository.GetUser(id);
        EnforceRole(user.AccessRole);
        return user;
    }
