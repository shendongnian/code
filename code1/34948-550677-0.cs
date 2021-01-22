        static bool IsInRole(string role)
        {
            IPrincipal principal = Thread.CurrentPrincipal;
            return principal != null && principal.IsInRole(role);
        }
        ...
        bool isAdmin = IsInRole("ADMIN");
