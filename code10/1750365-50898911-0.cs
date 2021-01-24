    [HttpGet]
    [Authorize(Roles = "Badmin")]
    [Route("GetUsers")]
    public async Task<IActionResult> GetUsers() {
        var users = await _context.ApplicationUsers.AsNoTracking().ToListAsync();
        return Json(users);
    }
