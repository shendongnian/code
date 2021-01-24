    [HttpGet]
    public async Task<bool> Test()
    {
        var userFromManager = await _userManager.GetUserAsync(User);
        var externalAccessToken = await _userManager.GetAuthenticationTokenAsync(
                                       userFromManager, "Coinbase", "access_token");
        return true;
    }
