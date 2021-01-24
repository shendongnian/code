    public class ValidSessionHandler : AuthorizationHandler<ValidSessionRequirement>
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        public ValidSessionHandler(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
        }
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, ValidSessionRequirement requirement)
        {
            // if the user isn't authenticated then no need to check session
            if (!context.User.Identity.IsAuthenticated)
                return;
            var authorizationFilterContext = context.Resource as AuthorizationFilterContext;
            // get the user and session claim
            var user = await _userManager.GetUserAsync(context.User);
            var claims = await _userManager.GetClaimsAsync(user);
            // get roles and skip check if Admin or SuperAdmin
            var roles = await _userManager.GetRolesAsync(user);
            foreach(var role in roles)
            {
                if(role == "Admin" || role == "SuperAdmin")
                {
                    context.Succeed(requirement);
                    return;
                }
            }
            var serverSession = claims.First(e => e.Type == "session");
            var clientSession = context.User.FindFirst("session");
            // if the client session matches the server session then the user is authorized
            if (serverSession?.Value == clientSession?.Value)
            {
                context.Succeed(requirement);
            }
            return;
        }
    }
