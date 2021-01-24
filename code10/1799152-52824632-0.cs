    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<bool> CheckCurrentPassword(string username, string password)
    {
        var originalUser = await _userManager.FindByNameAsync(username);
        // originalUser might be null (as in your example), so check for that accordingly.
        return await _userManager.CheckPasswordAsync(originalUser, password);
    }
