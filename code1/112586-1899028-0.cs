    static bool IsInRole(string role) {
        if (string.IsNullOrEmpty(role)) return true;
        IPrincipal principal = Thread.CurrentPrincipal;
        return principal == null ? false : principal.IsInRole(role);
    }
    public bool CanGotoHome   
        get { IsInRole(AccessRights.GotoHome); } 
    }
