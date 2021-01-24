    [HttpGet]
    public IActionResult Test([ModelBinder(typeof(HashSetBinder))] IEnumerable<string> values)
    {
        return Ok(new
        {
            values
        });
    }
