    services.AddScoped<Session>();
Session.cs
    public class Session
    {
        public long? UserId { get; set; }
        public int? TenantId { get; set; }
        public string Subdomain { get; set; }
    }
AppInitializationFilter.cs
    public class AppInitializationFilter : IAsyncActionFilter
    {
        private Session _session;
        private DBContextWithUserAuditing _dbContext;
        private ITenantService _tenantService;
        public AppInitializationFilter(
            Session session,
            DBContextWithUserAuditing dbContext,
            ITenantService tenantService
            )
        {
            _session = session;
            _dbContext = dbContext;
            _tenantService = tenantService;
        }
        public async Task OnActionExecutionAsync(
            ActionExecutingContext context,
            ActionExecutionDelegate next
            )
        {
            string userId = null;
            int? tenantId = null;
            var claimsIdentity = (ClaimsIdentity)context.HttpContext.User.Identity;
            var userIdClaim = claimsIdentity.Claims.SingleOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            if (userIdClaim != null)
            {
                userId = userIdClaim.Value;
            }
            var tenantIdClaim = claimsIdentity.Claims.SingleOrDefault(c => c.Type == CustomClaims.TenantId);
            if (tenantIdClaim != null)
            {
                tenantId = !string.IsNullOrEmpty(tenantIdClaim.Value) ? int.Parse(tenantIdClaim.Value) : (int?)null;
            }
            _dbContext.UserId = userId;
            _dbContext.TenantId = tenantId;
            string subdomain = context.HttpContext.Request.GetSubDomain();
            _session.UserId = userId;
            _session.TenantId = tenantId;
            _session.Subdomain = subdomain;
            _tenantService.SetSubDomain(subdomain);
            var resultContext = await next();
        }
    }
AuthController.cs
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : Controller
    {
        public IConfigurationRoot Config { get; set; }
        public IUserService UserService { get; set; }
        public ITenantService TenantService { get; set; }
        [AllowAnonymous]
        [HttpPost]
        public async Task<AuthenticateOutput> Authenticate([FromBody] AuthenticateInput input)
        {
            var expires = input.RememberMe ? DateTime.UtcNow.AddDays(5) : DateTime.UtcNow.AddMinutes(20);
            var user = await UserService.Authenticate(input.UserName, input.Password);
            if (user == null)
            {
                throw new Exception("Unauthorised");
            }
            int? tenantId = TenantService.GetTenantId();
            string strTenantId = tenantId.HasValue ? tenantId.ToString() : string.Empty;
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Expires = expires,
                Issuer = Config.GetValidIssuer(),
                Audience = Config.GetValidAudience(),
                SigningCredentials = new SigningCredentials(Config.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256),
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.NameIdentifier, user.Id),
                    new Claim(CustomClaims.TenantId, strTenantId)
                })
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            string tokenString = tokenHandler.WriteToken(token);
            return new AuthenticateOutput() { Token = tokenString };
        }
    }
