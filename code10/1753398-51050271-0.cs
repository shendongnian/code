    [HttpGet]
    [Route("example/{id}")]
    public Task<Example> GetExample(int id)
    {
        return exampleService.GetExampleAsync(id);
    }
