    [HttpGet]
    public IHttpActionResult ApiName()
    {
        var myObject = new Item1 { Id = 1, Name = "Matthew", Salary = 25000, Department = null };
        
        var jsonIgnoreNullValues = JsonConvert.SerializeObject(myObject, Newtonsoft.Json.Formatting.Indented, new JsonSerializerSettings
            {
              NullValueHandling = NullValueHandling.Ignore
            });
        
        JObject jObject = JObject.Parse(jsonIgnoreNullValues);
        
        return Ok(jObject);
    }
