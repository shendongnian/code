    [HttpPost]
    [Route("api/test")]
    public HttpResponseMessage TestMethod(HttpRequestMessage request)
    {
        NameValueCollection collection = HttpContext.Current.Request.Form;
    
        var items = collection.AllKeys.SelectMany(collection.GetValues, (k, v) => new { key = k, value = v });
    
        Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
    
        foreach (var item in items)
        {
            keyValuePairs.Add(item.key, item.value);
        }
    
        return Request.CreateResponse(HttpStatusCode.OK, keyValuePairs);
    }
