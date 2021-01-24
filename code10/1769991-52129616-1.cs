    services.AddScoped<SessionContext>();
SessionContext.cs
    public class SessionContext
    {
        public long? UserId { get; set; }
        public int? TenantId { get; set; }
        public string Subdomain { get; set; }
    }
SessionFilter.cs
    public class SessionFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(
            ActionExecutingContext context,
            ActionExecutionDelegate next
            )
        {
            var services = context.HttpContext.RequestServices;
            var session = services.GetService(typeof(SessionContext)) as SessionContext;
            var claimsIdentity = (ClaimsIdentity)context.HttpContext.User.Identity;
            var userIdClaim = claimsIdentity.Claims.SingleOrDefault(c => c.Type == CustomClaims.UserId);
            if (userIdClaim != null)
            {
                session.UserId = !string.IsNullOrEmpty(userIdClaim.Value) ? long.Parse(userIdClaim.Value) : (long?)null;
            }
            var tenantIdClaim = claimsIdentity.Claims.SingleOrDefault(c => c.Type == CustomClaims.TenantId);
            if (tenantIdClaim != null)
            {
                session.TenantId = !string.IsNullOrEmpty(tenantIdClaim.Value) ? int.Parse(tenantIdClaim.Value) : (int?)null;
            }
            session.Subdomain = context.HttpContext.Request.GetSubDomain();
            var resultContext = await next();
        }
    }
AuthController.cs
    [AllowAnonymous]
    [HttpPost]
    public async Task<AuthenticateOutput> Authenticate([FromBody] AuthenticateInput input)
    {
        var expires = input.RememberMe ? DateTime.UtcNow.AddDays(5) : DateTime.UtcNow.AddMinutes(20);
        string subdomain = HttpContext.Request.GetSubDomain();
        _tenantService.SetSubDomain(subdomain);
        var user = await _userService.Authenticate(input.UserName, input.Password);
        if (user == null)
        {
            throw new Exception("Unauthorised");
        }
        int? tenantId = _tenantService.GetTenantId();
        string strTenantId = tenantId.HasValue ? tenantId.ToString() : string.Empty;
        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Expires = expires,
            Issuer = _config.GetValidIssuer(),
            Audience = _config.GetValidAudience(),
            SigningCredentials = new SigningCredentials(_config.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256),
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                // claims required for SessionContext
                new Claim(CustomClaims.UserId, user.Id.ToString()),
                new Claim(CustomClaims.TenantId, strTenantId)
            })
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        string tokenString = tokenHandler.WriteToken(token);
        return new AuthenticateOutput() { Token = tokenString };
    }
