    [HttpPost]
    [Route("test")]
    public async Task TestMethod(HttpRequestMessage request)
    {
        var jObject = await request.Content.ReadAsAsync<JObject>();
    
        Sample sample = JsonConvert.DeserializeObject<Sample>(jObject.ToString());
    }
