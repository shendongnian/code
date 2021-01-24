    public class AccountController : Controller
    {
        public IActionResult SignUp()
        {
            return new ChallengeResult(
                AzureADB2CDefaults.OpenIdScheme,
                new AuthenticationProperties()
                {
                    RedirectUri = Url.Action("Start", "Onboarding", values: null, protocol: Request.Scheme)
                });
        }
    }
