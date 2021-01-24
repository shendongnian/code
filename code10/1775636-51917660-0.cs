    [HttpGet]
    [Produces("application/json")]
    [Route("whatever")]
    public IActionResult Get() {
        var model = new { city = "paris" };
        return Ok(model);
    }
