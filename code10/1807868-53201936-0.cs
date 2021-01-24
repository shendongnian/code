                public class PermissionHandler : IAuthorizationHandler
        {
            public Task HandleAsync(AuthorizationHandlerContext context)
            {
                var pendingRequirements = context.PendingRequirements.ToList();
                foreach (var requirement in pendingRequirements)
                {
                    if (requirement is ReadPermission)
                    {
                        if (IsOwner(context.User, context.Resource) ||
                            IsAdmin(context.User, context.Resource))
                        {
                            context.Succeed(requirement);
                        }
                    }
                    else if (requirement is EditPermission ||
                             requirement is DeletePermission)
                    {
                        if (IsOwner(context.User, context.Resource))
                        {
                            context.Succeed(requirement);
                        }
                    }
                }
                return Task.CompletedTask;
            }
            private bool IsAdmin(ClaimsPrincipal user, object resource)
            {
                if (user.IsInRole("Admin"))
                {
                    return true;
                }
                return false;
            }
            private bool IsOwner(ClaimsPrincipal user, object resource)
            {
                // Code omitted for brevity
                return true;
            }
            private bool IsSponsor(ClaimsPrincipal user, object resource)
            {
                // Code omitted for brevity
                return true;
            }
        }
