    services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    })
    .AddCookie(options =>{
        options.ForwardChallenge ="MyOIDC";
    })
    .AddOpenIdConnect("MyOIDC", options =>
    {
         // ....
    }
2. Approach 2 : invoke challenge scheme manually :
    public class AccountController : Controller
    {
        public async Task Login(string returnUrl = "/")
        {
            await HttpContext.ChallengeAsync("MyOIDC", new AuthenticationProperties() { RedirectUri = returnUrl });
        }
        
        // if you need sign out the MyOIDC service, you could sign out the user for two schemes as below :
        [Authorize]
        public async Task Logout()
        {
            await HttpContext.SignOutAsync("MyOIDC", new AuthenticationProperties
            {
                RedirectUri = Url.Action("Index", "Home")
            });
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }
    }
