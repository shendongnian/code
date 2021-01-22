    public class SystemAdministratorAuthorizationRequiredAttribute
    		: AuthorizeAttribute
    	{
    		protected override bool AuthorizeCore(System.Security.Principal.IPrincipal user)
    		{
    			return
    				user.IsInRole(
    				StringResources.AdministrationViewsStrings.SystemAdministratorRoleName
    				);
    		}
    	}
