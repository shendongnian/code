    public static bool IsInRole(string role)
    {
        var principal = Thread.CurrentPrincipal;
        return principal == null ? false : principal.IsInRole(role);
    }
