    var jsonSerializerSettings = new JsonSerializerSettings()
    {
         DateTimeZoneHandling = DateTimeZoneHandling.Local
    };
    var obj = JsonConvert.DeserializeObject<DateTime>(sDate, jsonSerializerSettings);
