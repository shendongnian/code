    using System.DirectoryServices.AccountManagement;
    using System.Linq;
    ...
    
    using (var ctx = new PrincipalContext(ContextType.Domain, yourDomain)) {
        using (var grp = GroupPrincipal.FindByIdentity(ctx, IdentityType.Name, yourGroup)) {
            bool isInRole = grp != null && 
                grp
                .GetMembers(true)
                .Any(m => m.SamAccountName == me.Identity.Name.Replace(yourDomain + "\\", ""));
        }
    }
