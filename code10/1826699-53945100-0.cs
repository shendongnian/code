    [HttpGet("Get2")]
    [Produces("application/json", "application/xml", Type = typeof(List<string>))]
    public IActionResult Get2()
    {
       var list = new List<string>() { "value1", "value2" };
       return Ok(list);
    }
