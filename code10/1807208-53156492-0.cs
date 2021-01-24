    [HttpPost]
    public void Post([FromBody] Input input)
    {
        var apiKey = input.ApiKey;
        // etc
    }
