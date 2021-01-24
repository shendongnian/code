    public class AuthenticationHandler : AuthenticationService
    	{
    		private readonly ILdapRepository _ldapRepository;
    		public AuthenticationHandler(ILdapRepository ldapRepository,
    			IAuthenticationSchemeProvider schemes, IAuthenticationHandlerProvider handlers,
    			IClaimsTransformation transform) : base(schemes, handlers, transform)
    		{
    			_ldapRepository = ldapRepository;
    		}
    		public async override Task<AuthenticateResult> AuthenticateAsync(HttpContext context, string scheme)
    		{
    			var idk = await base.AuthenticateAsync(context, scheme);
    			if (idk.Succeeded) {
    				var claims = _ldapRepository.LoadClaimsFromActiveDirectory(idk.Principal.Claims.FirstOrDefault(x => x.Type == CustomClaimTypes.Name)?.Value);
    				idk.Principal.AddIdentity(claims);
    			}
    			return idk;
    		}
    }
