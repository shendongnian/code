    [HttpPost, Route("api/MyControllerName/MyMethodName")]
    public async Task PostNewIds([FromBody] string body)
    {
        var obj = JsonConvert.DeserializeObject(ids) as JObject;
        var val = obj["ids"] as JValue;
        Debug.WriteLine(val.Value);
    }
