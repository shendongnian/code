        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        ....
       /// <summary>
        /// Handle postback from username/password login
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginInputModel model, string button)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return await ReturnLoginError(model);
                }
                ApplicationUser user = await _userManager.FindByEmailAsync(model.Email) 
                                       ?? await _userManager.FindByNameAsync(model.Username);
                SignInResult signInResult = await _signInManager.PasswordSignInAsync(user, model.Password, isPersistent: true,
                    lockoutOnFailure: true);
                 ...
          }
 
