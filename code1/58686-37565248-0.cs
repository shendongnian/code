    using (var context = new PrincipalContext(ContextType.Domain))
    using (var user = new UserPrincipal(context)
    {
        UserPrincipalName = "username",
        Enabled = true
    })
    {
        user.SetPassword("password");
        user.Save();
    }
