    class MyEnumConverter : JsonConverter<MyEnum>
    {
      public override MyEnum ReadJson(JsonReader reader, Type objectType, MyEnum existingValue, bool hasExistingValue, JsonSerializer serializer)
      {
        var token = reader.Value as string ?? reader.Value.ToString();
        var stripped = Regex.Replace(token, @"<[^>]+>", string.Empty);
        if (Enum.TryParse<MyEnum>(stripped, out var result))
        {
          return result;
        }
        return default(MyEnum);
      }
      public override void WriteJson(JsonWriter writer, MyEnum value, JsonSerializer serializer)
      {
        writer.WriteValue(value.ToString());
      }
    }
