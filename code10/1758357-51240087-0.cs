    JsonSerializerSettings settings = new JsonSerializerSettings
    {
        DateTimeZoneHandling = DateTimeZoneHandling.Utc,
    };
    
    var json = JsonConvert.SerializeObject(a, settings);
    
    var newA = JsonConvert.DeserializeObject<A>(json, settings);
