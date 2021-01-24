    public class AccountController : Controller
    {
        public IActionResult SignUp()
        {
            return this.Challenge(
                new AuthenticationProperties()
                {
                    RedirectUri = Url.Action("Start", "Onboarding", values: null, protocol: Request.Scheme)
                },
                AzureADB2CDefaults.AuthenticationScheme);
        }
    }
