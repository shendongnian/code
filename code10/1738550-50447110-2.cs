    public class ObjectDictionaryConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (typeof(IDictionary).IsAssignableFrom(objectType) ||
                    TypeImplementsGenericInterface(objectType, typeof(IDictionary<,>)));
        }
    
        private static bool TypeImplementsGenericInterface(Type concreteType, Type interfaceType)
        {
            return concreteType.GetInterfaces()
                    .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == interfaceType);
        }
    
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var dictionary = (IDictionary)value;
            writer.WriteStartArray();
            foreach ( var key in dictionary.Keys)
            {
                var keysValue = dictionary[key];
                writer.WriteStartObject();
                writer.WritePropertyName(key.ToString());
                writer.WriteValue(keysValue);
                writer.WriteEndObject();
            }
            writer.WriteEndArray();
        }
    
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
