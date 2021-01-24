    public class CustomAuthorize : AuthorizeAttribute
    {
        public CustomAuthorize(PermissionItem item, params PermissionAction[] actions)
        {
            //Need to initalize the Permission Enums
        }
    
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            //Code to get the value from Permissions ArrayList and compare it with the Enum values
        }
    }
