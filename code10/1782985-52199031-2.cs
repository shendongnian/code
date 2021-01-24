    [Route("api/statistics")]
    [HttpPost]
    public async Task Post([FromBody] Statistics value)
    {
        var stats = new List<Statistics>();
        stats.Add(value);
        // and some other code ...
        var _user = await _userManager.GetUserAsync(HttpContext.User);
        // ...
    }
