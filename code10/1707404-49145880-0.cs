         switch (result)
        {
            case SignInStatus.Success:
          ApplicationUser CurrentUser = UserManager.FindByEmail(model.Email);
    //Use this "CurrentUser" Id for your function.
            case SignInStatus.LockedOut:
                return View("Lockout");
            case SignInStatus.RequiresVerification:
                return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
            case SignInStatus.Failure:
            default:
                ModelState.AddModelError("", "Invalid login attempt.If you do not have an account please register one");
                return View(model);
        }
