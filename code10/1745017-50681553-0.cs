    [HttpGet]
    public async Task<IActionResult> GetPicture(string username)
    {
        var user = await _userManager.FindByNameAsync(username);
        var bytes = Convert.FromBase64String(user.Picture);
        return File(bytes, "image/jpeg");
    }
