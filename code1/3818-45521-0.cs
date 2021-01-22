    public static bool IsUserInGroup(string username, string groupname, ContextType type)
    {
        PrincipalContext context = new PrincipalContext(type);
        UserPrincipal user = UserPrincipal.FindByIdentity(
            context,
            IdentityType.SamAccountName,
            username);
        GroupPrincipal group = GroupPrincipal.FindByIdentity(
            context, groupname);
        return user.IsMemberOf(group);
    }
