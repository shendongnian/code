    // This class is what allows you to use [Authorize(Roles="Role")] and check the roles with the custom logic implemented in the user store (by default, roles are checked against the ClaimsPrincipal roles claims)
    public class CustomRoleChecker : AuthorizationHandler<RolesAuthorizationRequirement>
    {
        private readonly UserManager<User> _userManager;
        public CustomRoleChecker(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, RolesAuthorizationRequirement requirement)
        {
            var user = await _userManager.GetUserAsync(context.User);
            
            // for simplicity, I use only one role at a time in the attribute
            var singleRole = requirement.AllowedRoles.Single();
            if (await _userManager.IsInRoleAsync(user, singleRole))
                context.Succeed(requirement);
        }
    }
    public void ConfigureServices(IServiceCollection services)
    {
	    services
		.AddIdentity<User, Role>()
		.AddUserStore<MyUserStore>()
		.AddRoleStore<MyRoleStore>();
        // custom role checks, to check the roles in DB 
       services.AddScoped<IAuthorizationHandler, CustomRoleChecker>();
    }
