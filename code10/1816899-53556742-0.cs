    public async Task<IActionResult> Logout()
    {
       await _signInManager.SignOutAsync();
       return View("Logout"); // or whatever url
    }
