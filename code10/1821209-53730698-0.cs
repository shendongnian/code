    public class RegisterModel : PageModel
    {
        private readonly IdentityOptions identityOptions;
        public RegisterModel(IOptions<IdentityOptions> identityOptions)
        {
            this.identityOptions = identityOptions.Value;
        }
        public void OnGet()
        {
            identityOptions.Password.RequireDigit; // etc
        }
    }
