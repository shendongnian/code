    [HttpGet("api/items")]
    public IActionResult GetItems(Dictionary<string, int> created)
    {
        return Ok(new { created });
    }
