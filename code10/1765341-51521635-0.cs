    public async Task<ActionResult> Register(RegisterViewModel model)
    {
      if (ModelState.IsValid) {
        var user = new ApplicationUser() { UserName = model.UserName,
          MagicCode = model.MagicCode };
        var result = await UserManager.CreateAsync(user, model.Password);
        if (result.Succeeded) {
          await SignInAsync(user, isPersistent: false);
          return RedirectToAction("Index", "Home");
        }
    }
