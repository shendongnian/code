    [Authorize(AuthenticationSchemes = "Cookies,Bearer")]
    public IActionResult UserInfo()
    {
        return Json(User.Claims.Select(c => new { key = c.Type, value = c.Value }));
    }
