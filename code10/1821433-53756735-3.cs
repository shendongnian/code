    // Sign in the user with this external login provider if the user already has a login.
    var result = await _signInManager.ExternalLoginSignInAsync("YourProvider", userIdClaim.Value, isPersistent: false, bypassTwoFactor: true);
    if (result.Succeeded)
    {
        _logger.LogInformation("User logged in with {Name} provider.", "YourProvider");
        // delete temporary cookie used during external authentication
        await HttpContext.SignOutAsync(IdentityServerConstants.ExternalCookieAuthenticationScheme);
        return RedirectToLocal(returnUrl);
    }
    if (result.IsLockedOut)
    {
        return RedirectToAction(nameof(Lockout));
    }
    else
    {
        // If the user does not have an account, then ask the user to create an account.
        ViewData["ReturnUrl"] = returnUrl;
        ViewData["LoginProvider"] = "YourProvider";
        var email = claims.FirstOrDefault(x => x.Type == ClaimTypes.Upn).Value;
        return View("ExternalLogin", new ExternalLoginViewModel { Email = email });
    }
