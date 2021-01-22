    using System.DirectoryServices.AccountManagement;
    bool UserExists(string userName, string domain) {
        using (var pc = new PrincipalContext(ContextType.Domain, domain))
        using (var p = Principal.FindByIdentity(pc, IdentityType.SamAccountName, userName)) {
            return p != null;
        }
    }
