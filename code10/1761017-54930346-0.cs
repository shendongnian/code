    [HttpGet]
    [Authorize(Roles = "admin")]
    public async Task<IActionResult> GenerateCode([FromQuery(Name="email")] string email)
    {
    }
