    var signinResult = await _signInManager.PasswordSignInAsync(
        loginViewModel.UserName,
        loginViewModel.Password,
        false, false);
    if (signinResult.IsNotAllowed)
    {
        var user = await _userManager.FindByNameAsync(loginViewModel.UserName);
        if (!await _userManager.IsEmailConfirmedAsync(user))
        {
            // Email isn't confirmed.
        }
        if (!await _userManager.IsPhoneNumberConfirmedAsync(user))
        {
            // Phone Number isn't confirmed.
        }
    }
