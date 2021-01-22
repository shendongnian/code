    PrincipalContext ctx = new PrincipalContext(ContextType.Domain, "YOURDOMAIN");
    UserPrincipal toBeModified = UserPrincipal.FindByIdentity(".....");
    UserPrincipal manager = UserPrincipal.FindByIdentity(ctx, "......");
    DirectoryEntry de = toBeModified.GetUnderlyingObject() as DirectoryEntry;
    if (de != null)
    {
        de.Properties["managedBy"].Value = manager.DistinguishedName;
        toBeModified.Save();
    }
