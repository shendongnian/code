    ...
    if (user != null && await _userManager.CheckPasswordAsync(user, model.Password)) {
        await _events.RaiseAsync(
            new UserLoginSuccessEvent(user.UserName, user.Id, user.UserName));
    
    
        AuthenticationProperties props = null;
        if (AccountOptions.AllowRememberLogin && model.RememberLogin) {
            props = new AuthenticationProperties {
                IsPersistent = true,
                ExpiresUtc = DateTimeOffset.UtcNow.Add(AccountOptions.RememberMeLoginDuration)
            };
        };
    
        await HttpContext.SignInAsync(user.Id, user.UserName, props);
        ...
    }
