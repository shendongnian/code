    public class RoleVerificationHandler : AuthorizationHandler<RolesFilter> {
        private readonly IMyDependency dependency;
        public RoleVerificationHandler(IMyDependency dependency) {
            this.dependency = dependency;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, RolesFilter requirement)
        {
            //get roles based on app id, then check if the user has the correct role
            var roles = context.User.Claims.Where(c => c.Type == "Roles").Select(c => c.Value).ToList();
            foreach(var item in roles) {
                var currentItem = JsonConvert.DeserializeObject<UserRoleDetailsViewModel>(item);
                UserRoleDetailsViewModel urdvm = new UserRoleDetailsViewModel {
                    Id = currentItem.Id,
                    Name = currentItem.Name,
                    ApplicationId = currentItem.ApplicationId,
                    ApplicationName = currentItem.ApplicationName
                };
                if(requirement.Role == urdvm.Name && urdvm.ApplicationName == ApplicationGlobals.ApplicationName) {
                    context.Succeed(requirement);
                }    
            }
            return Task.CompletedTask;
        }
    }
