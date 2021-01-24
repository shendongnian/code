    public class ADSecurity
    {
        public static string getUserName(string sam)
        {
            PrincipalContext ctx = new PrincipalContext(ContextType.Domain, null, username, password);
            UserPrincipal user = UserPrincipal.FindByIdentity(ctx, IdentityType.SamAccountName, sam);
            return user.Name;
        }
    }
