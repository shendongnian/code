            private readonly SignInManager<IdentityUser> _signInManager;
            private readonly ILogger<LogoutModel> _logger;
            private readonly IIdentityServerInteractionService _interaction;
            public LogoutModel(SignInManager<IdentityUser> signInManager, ILogger<LogoutModel> logger,
                IIdentityServerInteractionService interaction)
            {
                _signInManager = signInManager;
                _logger = logger;
                _interaction = interaction;
            }
    
            public async Task<IActionResult> OnGet(string logoutId)
            {
                return await OnPost(logoutId);
            }
    
            public async Task<IActionResult> OnPost(string logoutId)
            {
                await _signInManager.SignOutAsync();
                _logger.LogInformation("User logged out.");
                var r = await _interaction.GetLogoutContextAsync(logoutId);
                if (r.PostLogoutRedirectUri == null)
                {
                    return Redirect("/");
                }
                return Redirect(r.PostLogoutRedirectUri);
            }
