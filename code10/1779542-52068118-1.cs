    public static async Task<HttpResponseMessage> Put(string requestUri, object value)
    {
        var builder = new HttpRequestBuilder()
            .AddMethod(HttpMethod.Put)
            .AddRequestUri(requestUri)
            .AddContent(JsonConvert.SerializeObject(value, Encoding.UTF8, "application/json"));
    
        return await builder.SendAsync();
    }
