    [HttpGet]
    public IActionResult GetTestBson()
    {
        return Ok(new { Value = "test string bson" });
    }
