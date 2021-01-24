    class SomeModel
    {
      [JsonConverter(typeof(OccuranceConverter))]
      public string Occurence { get; set; }
    }
    class OccuranceConverter : JsonConverter<string>
    {
      public override string ReadJson(JsonReader reader, Type objectType, string existingValue, bool hasExistingValue, JsonSerializer serializer)
      {
        var json = JObject.Load(reader);
        return json.GetValue("type").Value<string>();
      }
      public override void WriteJson(JsonWriter writer, string value, JsonSerializer serializer)
      {
        var json = new JObject { ["type"] = value };
        json.WriteTo(writer);
      }
    }
