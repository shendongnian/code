    [HttpGet("")]
    public IActionResult GetDate(DateTime date)
    {
        return Ok(date.ToString("o"));
    }
