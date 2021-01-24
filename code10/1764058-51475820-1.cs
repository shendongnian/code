    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, shouldLockout: false);
        
        switch (result)
        {
            case SignInStatus.Success:
                 var user = await UserManager.FindAsync(model.Email, model.Password);
        
                 if (user == null)
                 {
                     // user not found or login failure, do something here
                 }
                 else 
                 {
                     // proceed to role checking
                     var roles = await UserManager.GetRolesAsync(user.Id);
                     // use roles.Contains("SuperAdmin") if IsInRole still won't work 
                     if (UserManager.IsInRole(user.Id, "SuperAdmin"))
                     {
                         return RedirectToLocal(returnUrl);
                     }
                     else
                     {
                         ModelState.AddModelError("", "you are not allowed to access this page");
                         return View(model);
                     }
                 }      
                 
                 break;
            case SignInStatus.LockedOut:
                 return View("Lockout");
            case SignInStatus.RequiresVerification:
                 return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
            case SignInStatus.Failure:
            default:
                 ModelState.AddModelError("", "Invalid login attempt.");
        }
    
        return View(model);
    }
