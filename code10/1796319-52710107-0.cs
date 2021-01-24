    [Authorize(AuthenticationSchemes=JwtBearerDefaults.AuthenticationScheme)]
    public async Task<IActionResult> Login()
    {
        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, User);
        return View();
    }
