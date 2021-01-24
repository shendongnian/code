        public class LoginModel : PageModel
        {
            private readonly SignInManager<IdentityUser<int>> _signInManager;
            private readonly ILogger<LoginModel> _logger;
            public LoginModel(SignInManager<IdentityUser<int>> signInManager, ILogger<LoginModel> logger)
            {
                _signInManager = signInManager;
                _logger = logger;
            }
            //rest code
            public async Task<IActionResult> OnPostAsync(string returnUrl = null)
            {
                returnUrl = returnUrl ?? Url.Content("~/");
                if (ModelState.IsValid)
                {
                    // This doesn't count login failures towards account lockout
                    // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                    var result = await _signInManager.PasswordSignInAsync(Input.Email, Input.Password, Input.RememberMe, lockoutOnFailure: true);
                    if (result.Succeeded)
                    {
                        _logger.LogInformation("User logged in.");
                        return LocalRedirect($"~/Identity/Account/Login?handler=SetIdentity&returnUrl={returnUrl}");
                    }
                    if (result.RequiresTwoFactor)
                    {
                        return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, RememberMe = Input.RememberMe });
                    }
                    if (result.IsLockedOut)
                    {
                        _logger.LogWarning("User account locked out.");
                        return RedirectToPage("./Lockout");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                        return Page();
                    }
                }
                // If we got this far, something failed, redisplay form
                return Page();
            }
            public async Task<IActionResult> OnGetSetIdentityAsync(string returnUrl)
            {
                _logger.LogInformation(User.Identity.IsAuthenticated.ToString());
                return LocalRedirect(returnUrl);
            }
        }
