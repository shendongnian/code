    var signinResult = await _signInManager.PasswordSignInAsync(
        loginViewModel.UserName, loginViewModel.Password, false, false);
    var user = await _userManager.FindByNameAsync(loginViewModel.UserName);
    if (signinResult.IsNotAllowed)
    {
        if (!await _userManager.IsEmailConfirmedAsync(user))
        {
            // Email isn't confirmed.
        }
        if (!await _userManager.IsPhoneNumberConfirmedAsync(user))
        {
            // Phone Number isn't confirmed.
        }
    }
    else if (signinResult.IsLockedOut)
    {
        // Account is locked out.
    }
    else if (signinResult.RequiresTwoFactor)
    {
        // 2FA required.
    }
    else
    {
        // Username or password is incorrect.
        if (user == null)
        {
            // Username is incorrect.
        }
        else
        {
            // Password is incorrect.
        }
    }
