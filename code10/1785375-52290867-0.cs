    public class ApiKeyAuthHandler : AuthenticationHandler<ApiKeyAuthOpts>
    {
        public ApiKeyAuthHandler(IOptionsMonitor<ApiKeyAuthOpts> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock) 
            : base(options, logger, encoder, clock)
        {
        }
        
        private const string API_TOKEN_PREFIX = "api-key";
        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            string token = null;
            string authorization = Request.Headers["Authorization"];
            if (string.IsNullOrEmpty(authorization)) {
                return AuthenticateResult.NoResult();
            }
            if (authorization.StartsWith(API_TOKEN_PREFIX, StringComparison.OrdinalIgnoreCase)) {
                token = authorization.Substring(API_TOKEN_PREFIX.Length).Trim();
            }
            if (string.IsNullOrEmpty(token)) {
                return AuthenticateResult.NoResult();
            }
            
            // does the token match ?
            bool res =false; 
            using (DBContext db = new DBContext()) {
                var login = db.Login.FirstOrDefault(l => l.Apikey == token);  // query db
                res = login ==null ? false : true ; 
            }
            if (!res) {
                return AuthenticateResult.Fail($"token {API_TOKEN_PREFIX} not match");
            }
            else {
                var id=new ClaimsIdentity( 
                    new Claim[] { new Claim("Key", token) },  // not safe , just as an example , should custom claims on your own
                    Scheme.Name 
                );
                ClaimsPrincipal principal=new ClaimsPrincipal( id);
                var ticket = new AuthenticationTicket(principal, new AuthenticationProperties(), Scheme.Name);
                return AuthenticateResult.Success(ticket);
            }
        }
    }
