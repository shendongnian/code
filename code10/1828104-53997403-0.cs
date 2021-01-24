    public class CustomJsonConverter : JsonConverter
    {
        public override bool CanRead => false;
    
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Dictionary<string, string>);
        }
    
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var dictionary = (Dictionary<string, string>)value;
    
            writer.WriteStartObject();
    
            foreach (var key in dictionary.Keys)
            {
                if (dictionary[key] != null)
                {
                    writer.WritePropertyName(key);
    
                    serializer.Serialize(writer, dictionary[key]);
                }
            }
    
            writer.WriteEndObject();
        }
    }
