    [ApiController, Route("check")]
    public class TokenController : ControllerBase
    {
        private readonly SignInManager<IdentityUser> signin;
        public TokenController(SignInManager<IdentityUser> signin)
        {
            this.signin = signin;
        }
        [HttpGet]
        public async Task<string> Get(string user, string pass)
        {
            var result = await signin.PasswordSignInAsync(user, pass, true, false);
            if (result.Succeeded)
            {
                string token = "";
                return token;
            }
            return null;
        }
    }
