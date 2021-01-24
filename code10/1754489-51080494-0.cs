    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> doLogin(LoginInputModel model, string returnUrl = null)
    {
      if (User.Identity.IsAuthenticated)
      {
      
        return RedirectToAction("Index", "Home");
      }
      ViewData["ReturnUrl"] = returnUrl;
      if (ModelState.IsValid)
      {
    
     
        try {
        var result = await _signManager.PasswordSignInAsync(MyUser, model.Password, model.RememberMe, lockoutOnFailure: false);// ==>> model.RememberMe = true
      
        .
        .
        .
    }
