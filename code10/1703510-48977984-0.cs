    [HttpGet("{steamId64}", Name = "GetBan")]
    public async Task<IActionResult> GetBan([FromQuery] string apiKey, 
    [FromRoute] long steamId64)
    {
        // Code omitted
    }
