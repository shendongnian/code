    var str = "{\"ExpiresOn\":\"2018-07-09T11:22:33.45678\"}";
    Model test = JsonConvert.DeserializeObject<Model>(str, new JsonSerializerSettings()
    {
        DateTimeZoneHandling = DateTimeZoneHandling.Utc,
        DateParseHandling = DateParseHandling.DateTime
    });
    Assert(test.ExpiresOn.Offset.Ticks == 0);
