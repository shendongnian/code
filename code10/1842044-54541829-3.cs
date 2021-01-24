    HttpClient client = new HttpClient { BaseAddress = new Uri("ADDRESS") };
    var json = await client.GetAsync("/ENDPOINT");
    JsonSerializer serializer = JsonSerializer.CreateDefault();
    
    using (StringReader reader = new StringReader(json))
    {
         using (JsonTextReader jsonReader = new JsonTextReader(reader))
         {
              var result = serializer.Deserialize<OuterObject>(jsonReader);
         }
    }
