    public static async Task<HttpResponseMessage> Run( HttpRequestMessage req, TraceWriter log, ExecutionContext context )
    {
        string data = await req.Content.ReadAsStringAsync();
        dynamic parsed = JsonConvert.DeserializeObject(data);
        if (parsed == null)
        {
            parsed = req.GetQueryNameValuePairs().ToDictionary(kv => kv.Key, kv=> kv.Value, StringComparer.OrdinalIgnoreCase);
        }
    
        xxx
    }
