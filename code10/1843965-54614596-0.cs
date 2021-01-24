    [HttpGet]
    public IActionResult Gett([FromUri] oob ww)
    {
        return Ok(ww);
    }
