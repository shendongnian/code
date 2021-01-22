    private bool IsInGroup( GroupPrincipal group, UserPrincipal user )
    {
        if (group == null || group.Sid == null)
        {
            return false;
        }
        foreach (var g in user.GetAuthorizationGroups())
        {
             if ( g => g.Sid != null && g.Sid.CompareTo( group.Sid ) == 0 )
             {
                return true;
             }
        }
        return false;
    }
