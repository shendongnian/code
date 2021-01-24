    using (var context = new PrincipalContext(ContextType.Domain, $"{ServiceDomain}:636", ServiceDefaultLocation, ContextOptions.Negotiate, ServiceUser, ServicePassword))
    using (var identity = UserPrincipal.FindByIdentity(context, IdentityType.SamAccountName, "Jane"))
    {
        // identity.SetPassword("SomeNewPassword"); // also tried
        identity.ChangePassword("TheOldPassword", "SomeNewPassword"); // this is the error line
        identity.Save();
    }
