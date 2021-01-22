    using System.DirectoryServices.AccountManagement;
    using (PrincipalContext pc = new PrincipalContext(ContextType.Machine))
    {
    	UserPrincipal up = UserPrincipal.FindByIdentity(
    		pc,
    		IdentityType.SamAccountName,
    		"UserName");
    		
    	bool UserExists = (up != null);
    }
