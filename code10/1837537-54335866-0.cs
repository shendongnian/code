    public class AccountController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        public AccountController(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
        }
    
        public async Task<IActionResult> Login(string login, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(login, password, true, lockoutOnFailure: false);
    
            if (result.Succeeded)
            { 
                //process successful result
            }
            else
            {
                //process failed result
            }
        }
    }
