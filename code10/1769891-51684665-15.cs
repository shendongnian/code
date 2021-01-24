    [HttpPost]
    [Route("api/test")]
    public async Task TestMethod(HttpRequestMessage request)
    {
         var jObject = await request.Content.ReadAsAsync<JObject>();
    
         Item item = JsonConvert.DeserializeObject<Item>(jObject.ToString());
    }
