    public class SelectableAuthorizeAttribute : AuthorizeAttribute
    {
        public SelectableAuthorizeAttribute(params Type[] typesToExclude)
        {
            _typesToExlude = typesToExclude;
        }
        private readonly Type[] _typesToExlude;
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            bool skipAuthorization = _typesToExlude.Any(type => filterContext.ActionDescriptor.ControllerDescriptor.ControllerType == type);
            if (!skipAuthorization)
            {
                base.OnAuthorization(filterContext);
            }
        }
    }
