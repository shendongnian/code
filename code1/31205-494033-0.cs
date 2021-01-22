    string fullName = null;
    using (PrincipalContext context = new PrincipalContext( ContextType.Domain ))
    {
        using (UserPrincipal user
                = UserPrincipal.FindByIdentity( context,
                                                Environment.UserName ))
        {
            if (user != null)
            {
                fullName = user.DisplayName;
            }
        }
    }
