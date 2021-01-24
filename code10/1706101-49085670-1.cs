    /// <summary>
    ///  implement the interface called "IProfileService", which is used for authorization.
    /// </summary>
    public class ProfileService : IProfileService
    {
        IUserManager _myUserManager;
        private readonly ILogger<ProfileService> _logger;
        
        public ProfileService(ILogger<ProfileService> logger, IUserManager userManager)
        {
            _logger = logger;
            _myUserManager = userManager;
        }
 
        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {            
            var user = await _myUserManager.Find(context.UserName, context.Password);
            if (user != null)
            {
                context.Result = new GrantValidationResult(
                                 subject: user.USER_ID,
                                 authenticationMethod: "custom",
                                 claims: await _myUserManager.GetClaimsAsync(user));
            }
            else
            {                 
                context.Result = new GrantValidationResult(
                                 TokenRequestErrors.InvalidRequest, 
                        errorDescription: "UserName or Password Incorrect.");
            }             
        }
     
        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            _logger.LogDebug("Get profile called for {subject} from {client} with {claimTypes} because {caller}",
                context.Subject.GetSubjectId(),
                context.Client.ClientName,
                context.RequestedClaimTypes,
                context.Caller);
            var sub = context.Subject.FindFirst("sub")?.Value;
            if (sub != null)
            {
                var user = await _myUserManager.FindByNameAsync(sub);
                var cp = getClaims(user);
                var claims = cp.Claims;                
                context.IssuedClaims = claims.ToList();
            }
        }
        private ClaimsPrincipal getClaims(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            var id = new ClaimsIdentity();
           
            id.AddClaims(_myUserManager.GetClaimsAsync(user));
            return new ClaimsPrincipal(id);
        }
        /// <summary>
        /// Called by IdentityServer Middleware.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task IsActiveAsync(IsActiveContext context)
        {
            var sub = context.Subject.GetSubjectId();
            var user = await _myUserManager.FindByNameAsync(sub);
            context.IsActive = user != null;
            return;
        }
    }
