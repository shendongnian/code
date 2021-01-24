    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginInputModel model, string button)
    {
        if (ModelState.IsValid)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberLogin, lockoutOnFailure: true);
            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(model.Username);
                // Assume user has property IsActive for this example.
                // You can implement this anyway you like.
                if (user.IsActive)
                {
                    ...
                }
            }
            ModelState.AddModelError("", AccountOptions.InvalidCredentialsErrorMessage);
        }
        // something went wrong, show form with error
        var vm = await BuildLoginViewModelAsync(model);
        return View(vm);
    }
