    [HttpGet]
    [EnableCors("AllowSpecificOrigin")]
    public IEnumerable<string> Get()
    {
        return new string[] { "value1", "value2" };
    }
