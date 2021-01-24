	public class RawJsonConverter: JsonConverter
    {
      public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
      {
        return JObject.Load(reader).ToString();
      }
    
      public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
      {
        writer.WriteRawValue((string)value);
      }
    
      public override bool CanConvert(Type objectType)
      {
        return objectType == typeof(string);
      }
    }
