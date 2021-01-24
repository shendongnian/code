    var payload = JsonConvert.SerializeObject(myObject, new JsonSerializerSettings()
    {
        DateFormatHandling = DateFormatHandling.MicrosoftDateFormat
    });
 
    using (var sr = new StringReader(payload))
    using (var jr = new JsonTextReader(sr) { DateParseHandling = DateParseHandling.None })
    {
        var jot = JToken.ReadFrom(jr);
    }
