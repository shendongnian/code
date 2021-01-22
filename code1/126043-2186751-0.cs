    private bool IsInGroup( GroupPrincipal group, UserPrincipal user )
    {
        if (group == null || group.Sid == null)
        {
            return false;
        }
        return user.GetAuthorizationGroups()
                   .Any( g => g.Sid != null && g.Sid.CompareTo( group.Sid ) == 0 );
    }
