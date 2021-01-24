    public class AccountController : Controller {
        private readonly IWebService webService;
        public AccountController(IWebService webService) {
            this.webService = webService;
        }
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null) {
            if (ModelState.IsValid) {
                var result = await webService.PostRequestAsync<ResultObject>(Constants.UserLoginAPI, model);
                if (result.Succeeded) {
                    var output = JsonConvert.DeserializeObject<UserObject>(result.Object.ToString());
                    if (output != null && !string.IsNullOrEmpty(output.Email)) {
                        var userRoleInfo = await webService.GetRequestAsync<List<UserRoleObject>>(string.Format(Constants.GetUserRoleInfoAPI, output.Email));
                        if (userRoleInfo != null) {
                            var claims = new List<Claim>
                            {
                                new Claim(ClaimTypes.Name, output.Email),
                                new Claim("Username", output.UserName)
                            };
                            var claimsIdentity = new ClaimsIdentity(
                                claims, CookieAuthenticationDefaults.AuthenticationScheme);
                            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), new AuthenticationProperties { IsPersistent = model.RememberMe });
                        }
                        return View(new LoginViewModel());
                    }
                }
            }
            return View(model);
        }
    }
