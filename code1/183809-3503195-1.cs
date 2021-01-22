    using System;
    using System.DirectoryServices.AccountManagement;
    public static class DomainHelpers
    {    
        public string GetDistinguishedName(string domain, string guid)
        {
            var context = new PrincipalContext(ContextType.Domain, domain); 
            var userPrincipal  = UserPrincipal.FindByIdentity(context, IdentityType.Guid, guid);
        
            return userPrincipal.DistinguishedName;
        }
    }
