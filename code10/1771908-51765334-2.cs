    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Logout(LogoutInputModel model)
    {
        var vm = await BuildLoggedOutViewModelAsync(model.LogoutId);
        if (User?.Identity.IsAuthenticated == true)
        {
            await HttpContext.SignOutAsync();
            // ...
        }
        // ...
        return View("LoggedOut", vm);
    }
