    [HttpGet]
    public IActionResult Gett([FromQuery] oob ww)
    {
        return Ok(ww);
    }
