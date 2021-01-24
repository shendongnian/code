    public static void RegisterGlobalFilters(
        GlobalFilterCollection filters, Container container)
    {
        // Since PermissionFilter is a root type (i.e. directly resolved from the container),
        // it should be explicitly registered. This allows it to be verified.
        container.Register<PermissionFilter>();
        filters.Add(new AuthorizationFilterProxy<PermissionFilter>(container));
    }
