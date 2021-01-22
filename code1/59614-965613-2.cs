    private void AssertPermissions(IEnumerable<string> rolesDemanded)
    {
        IList<IIdentity> identities = OperationContext.Current.ServiceSecurityContext.AuthorizationContext.Properties["Identities"] as IList<IIdentity>;
        if (identities == null)
            throw new SecurityException("Unauthenticated access. No identities provided.");
        foreach (IIdentity identity in identities)
        {
            if (identity.IsAuthenticated == false)
                throw new SecurityException("Unauthenticated identity: " + identity.Name);
        }
        IIdentity usernameIdentity = identities.Where(id => id.GetType().Equals(typeof(GenericIdentity))).SingleOrDefault();
        string[] userRoles = Roles.GetRolesForUser(usernameIdentity.Name);
        foreach (string demandedRole in rolesDemanded)
        {
            if (userRoles.Contains(demandedRole) == false)
                throw new SecurityException("Access denied: authorisation failure.");
        }
    }
