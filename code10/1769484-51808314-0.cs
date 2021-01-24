    public class BlockedHandler : AuthorizationHandler<BlockedRequirement>
    {
        private Task HandleBlockedAsync(AuthorizationFilterContext filterContext)
        {
            // create a model for the view if needed...
            var model = new BlockedModel();
            // do some processing if needed...
            var modelMetadataProvider = filterContext.HttpContext.RequestServices.GetService<IModelMetadataProvider>();
            // short-circuit request by setting the action result
            filterContext.Result = new ViewResult
            {
                ViewName = "~/Views/Shared/Blocked.cshtml",
                ViewData = new ViewDataDictionary(modelMetadataProvider, filterContext.ModelState) { Model = model }
            };
            return Task.CompletedTask;
        }
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, BlockedRequirement requirement)
        {
            if (context.User.HasClaim(c => c.Type == UserClaimTypes.BlockedFrom) && 
                context.Resource is AuthorizationFilterContext filterContext &&
                filterContext.ActionDescriptor is ControllerActionDescriptor descriptor)
            {
                var allowBlocked = descriptor.ControllerTypeInfo.CustomAttributes
                    .Concat(descriptor.MethodInfo.CustomAttributes)
                    .Any(x => x.AttributeType == typeof(AllowBlockedAttribute));
                if (!allowBlocked)
                    await HandleBlockedAsync(filterContext);
            }
            // We must return success in every case to avoid forbid/challenge.
            context.Succeed(requirement);
        }
    }
