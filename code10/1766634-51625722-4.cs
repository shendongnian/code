    public class CustomAuthorize : System.Web.Http.AuthorizeAttribute
    {
    	private readonly PermissionAction[] permissionActions;
    
    	public CustomAuthorize(PermissionItem item, params PermissionAction[] permissionActions)
    	{
    		this.permissionActions = permissionActions;
    	}
    
    	protected override Boolean IsAuthorized(HttpActionContext actionContext)
    	{
    		var currentIdentity = actionContext.RequestContext.Principal.Identity;
    		if (!currentIdentity.IsAuthenticated)
    			return false;
    
    		var userName = currentIdentity.Name;
    		using (var context = new DataContext())
    		{
    			var userStore = new UserStore<AppUser>(context);
    			var userManager = new UserManager<AppUser>(userStore);
    			var user = userManager.FindByName(userName);
    
    			if (user == null)
    				return false;
    
    			foreach (var role in permissionActions)
    				if (!userManager.IsInRole(user.Id, Convert.ToString(role)))
    					return false;
    
    			return true;
    		}
    	}
    }
