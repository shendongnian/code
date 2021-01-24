    public class CustomAuthorize : AuthorizeAttribute
    {
        private readonly PermissionAction[] permissionActions;
    
        public CustomAuthorize(PermissionItem item, params PermissionAction[] permissionActions)
        {
            this.permissionActions = permissionActions;
        }
    
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var currentIdentity = System.Threading.Thread.CurrentPrincipal.Identity;
            if (!currentIdentity.IsAuthenticated) {
                // redirect to access denied page
            }
    
            var userName = currentIdentity.Name;
            // step 1 : retrieve user object
            
            // step 2 : retrieve user permissions
    
            // step 3 : match user permission(s) agains class/method's required premissions
            
            // step 4 : continue/redirect to access denied page
        }
    }
