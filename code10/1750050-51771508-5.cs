    [HttpGet("User")]
    public async Task<IActionResult> GetUser(string id)
    {
        var user = await _userManager.FindByIdAsync(id);     
        bool isAdmin= User.IsInRole("Admin");
        if (user == default(AppUser) || (User.Identity.Name != user.UserName && isAdmin == false))
        {
             return NotFound();
        }
        return Ok(user);
    }
