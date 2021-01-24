    public class RemoveEncryptedDataConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(JToken).IsAssignableFrom(objectType);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            JToken token = (JToken)value;
            if (token.Type == JTokenType.Object)
            {
                bool omitDataProperty = token.Value<string>("type") == "encrypted";
                writer.WriteStartObject();
                foreach (var prop in token.Children<JProperty>())
                {
                    if (omitDataProperty && prop.Name == "data")
                        continue;
                    writer.WritePropertyName(prop.Name);
                    serializer.Serialize(writer, prop.Value);  // recurse
                }
                writer.WriteEndObject();
            }
            else if (token.Type == JTokenType.Array)
            {
                writer.WriteStartArray();
                foreach (var item in token.Children())
                {
                    serializer.Serialize(writer, item);  // recurse
                }
                writer.WriteEndArray();
            }
            else // JValue
            {
                token.WriteTo(writer);
            }
        }
    }
