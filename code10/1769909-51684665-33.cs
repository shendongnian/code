    [HttpPost]
    [Route("api/test")]
    public async Task TestMethod(HttpRequestMessage request)
    {
        var test = await request.Content.ReadAsFormDataAsync();
    }
    
