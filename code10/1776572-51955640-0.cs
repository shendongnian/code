    public class ViewEditRolesHandler : AuthorizationHandler<ViewEditRolesRequirement>
    {
        private readonly IHttpContextAccessor _contextAccessor;
        public ViewEditRolesHandler(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ViewEditRolesRequirement requirement)
        {
            if (context.User != null)
            {
                var canView = requirement.ViewRoles.Any(r => context.User.IsInRole(r.ToString()));
                var canEdit = requirement.EditRoles.Any(r => context.User.IsInRole(r.ToString()));
                if (_contextAccessor.HttpContext.Request. // Now you have it!
            }
            return Task.CompletedTask;
        }
    }	
