    public class LoginViewComponent : ViewComponent
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public LoginViewComponent(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User).ConfigureAwait(false);
            return View(user);
        }
    }
