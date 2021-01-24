    public enum Permission
    {
        Read, Create, Write, Delete
    }
    
    public class PermissionAttribute : TypeFilterAttribute, IActionFilter
    {
        public PermissionAttribute(Permission p) : this(typeof(PermissionAttribute))
        {}
    
        public PermissionAttribute(Type type) : base(type)
        {}
    
        public void OnActionExecuted(ActionExecutedContext context)
        {
            // this is called
        }
    
        public void OnActionExecuting(ActionExecutingContext context)
        {
            // this is called
        }
    }
