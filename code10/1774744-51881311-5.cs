    public AdminController(
            UserManager<ApplicationUser> userManager,
            ILogger<AccountController> logger,
            IEmailSender emailSender,
            IRoleUtility roleUtility,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _logger = logger;
            _emailSender = emailSender;
            _roleUtility = roleUtility;
            _signInManager = signInManager;
        }
    
    private void PuplateRolesList(RegisterViewModel model)
        {
            _roleUtility.PopulateRolesList(model);
        }
