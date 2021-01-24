    [Authorize]
    public async Task<IActionResult> ClientUpdate(ClientModel client)
    {
        var accessToken = _httpContextAccessor.HttpContext.Request.Headers["Authorziation"];
    
        ..........//Some other code
        return View();
    }
