    class LikeTypeConverter : JsonConverter
    {
        static Type GetValueType(Type objectType)
        {
            return objectType
                .BaseTypesAndSelf()
                .Where(t => t.IsGenericType && t.GetGenericTypeDefinition() == typeof(LikeType<>))
                .Select(t => t.GetGenericArguments()[0])
                .FirstOrDefault();
        }
    
        public override bool CanConvert(Type objectType)
        {
            return GetValueType(objectType) != null;
        }
    
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            // You need to decide whether a null JSON token results in a null LikeType<T> or 
            // an allocated LikeType<T> with a null Value.
            if (reader.SkipComments().TokenType == JsonToken.Null)
                return null;
            var valueType = GetValueType(objectType);
            var value = serializer.Deserialize(reader, valueType);
    
            // Here we assume that every subclass of LikeType<T> has a constructor with a single argument, of type T.
            return Activator.CreateInstance(objectType, value);
        }
    
        const string ValuePropertyName = "Value";// nameof(LikeType<object>.Value); // in C#6+
    
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var contract = (JsonObjectContract)serializer.ContractResolver.ResolveContract(value.GetType());
            var valueProperty = contract.Properties.Single(p => p.UnderlyingName == ValuePropertyName);
            serializer.Serialize(writer, valueProperty.ValueProvider.GetValue(value));
        }
    }
    
    public static partial class JsonExtensions
    {
        public static JsonReader SkipComments(this JsonReader reader)
        {
            while (reader.TokenType == JsonToken.Comment && reader.Read())
            {
            }
    
            return reader;
        }
    }
    
    public static class TypeExtensions
    {
        public static IEnumerable<Type> BaseTypesAndSelf(this Type type)
        {
            while (type != null)
            {
                yield return type;
                type = type.BaseType;
            }
        }
    }
