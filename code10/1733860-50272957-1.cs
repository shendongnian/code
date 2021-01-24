    PrincipalContext ctx = new PrincipalContext(ContextType.ApplicationDirectory, "LDSServerHere:389", "OU HERE", "Acccount Name Here", "Password HEre");
    UserPrincipal u = UserPrincipal.FindByIdentity(ctx, IdentityType.SamAccountName, login);
    string prop = string.Empty;
    try
    {
        var de = (DirectoryEntry) u.GetUnderlyingObject();
        if (de.Properties.Contains("extensionAttribute10")) {
            prop = de.Properties["extensionAttribute10"].Value;
        }
    }
    catch (Exception ex)
    {
        prop = ex.ToString();
    }
    return prop;
