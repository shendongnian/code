    public async Task<IActionResult> SignInAnother()
    {
        //A sign in with username and password
        var AsignInResult = await _signInManager.PasswordSignInAsync("tony@outlook.com","1qaz@WSX", false, true);
        //A sign out
        await _signInManager.SignOutAsync();
        //query identity user by username
        var username = "test@outlook.com";
        var user = await _userManager.FindByNameAsync(username);
        //sign in user
        await _signInManager.SignInAsync(user, isPersistent: true);
        return RedirectToAction("Index");
    }
