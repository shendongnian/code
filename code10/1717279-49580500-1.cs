    public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
    {
        ViewData["ReturnUrl"] = returnUrl;
        if (ModelState.IsValid)
        {
            ApplicationUser user = await _userManager.FindByEmailAsync(model.Email);
            user.ActiveDealershipID = model.ChosenDealership
            await _userManager.UpdateAsync(user);
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                _logger.LogInformation("User logged in.");
                ...
