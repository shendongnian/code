    public class HelloController : Controller
    {
        private readonly AzureADB2CWithApiOptions _options;
        public HelloController(IOptions<AzureADB2CWithApiOptions> optionsAccessor)
        {
            _options = optionsAccessor.Value;
        }
        public async Task<IActionResult> Index()
        {
            var clientCredential = new ClientCredential(_options.ClientSecret);
            var userId = context.Principal.FindFirst(ClaimTypes.NameIdentifier).Value;
            var userTokenCache = new SessionTokenCache(HttpContext, userId);
            var confidentialClientApplication = new ConfidentialClientApplication(
                _options.ClientId,
                _options.Authority,
                _options.RedirectUri,
                clientCredential,
                userTokenCache.GetInstance(),
                null);
            var authenticationresult = await confidentialClientApplication.AcquireTokenSilentAsync(
                _options.ApiScopes.Split(' '),
                confidentialClientApplication.Users.FirstOrDefault(),
                _options.Authority,
                false);
            // TODO: Invoke the API endpoint by setting the Authorization header to "Bearer" + authenticationResult.AccessToken.
        }
    }
