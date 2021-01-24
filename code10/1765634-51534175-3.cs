    var serializer = new JsonSerializer();
    using (var stream= await response.Content.ReadAsStreamAsync())
    using (var sr = new StreamReader(stream))
    using (var jsonTextReader = new JsonTextReader(sr))
    {
        var jsonArray=JsonConvert.DeserializeObject<dynamic>(json);
        var payloadObject=jsonArray[0].payload;
        var payload=JsonConvert.DeserializeObject<dynamic>(payloadObject.Value);
    }
