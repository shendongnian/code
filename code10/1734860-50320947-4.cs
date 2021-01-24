    class ValueConverter : JsonConverter
    {
        static Type GetValueType(Type objectType)
        {
            return objectType
                .BaseTypesAndSelf()
                .Where(t => t.IsGenericType && t.GetGenericTypeDefinition() == typeof(ValueObject<>))
                .Select(t => t.GetGenericArguments()[0])
                .FirstOrDefault();
        }
        public override bool CanConvert(Type objectType)
        {
            return GetValueType(objectType) != null;
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            // You need to decide whether a null JSON token results in a null ValueObject<T> or 
            // an allocated ValueObject<T> with a null Value.
            if (reader.SkipComments().TokenType == JsonToken.Null)
                return null;
            var valueType = GetValueType(objectType);
            var value = serializer.Deserialize(reader, valueType);
            // Here we assume that every subclass of ValueObject<T> has a constructor with a single argument, of type T.
            return Activator.CreateInstance(objectType, value);
        }
        const string ValuePropertyName = nameof(ValueObject<object>.Value);
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var contract = (JsonObjectContract)serializer.ContractResolver.ResolveContract(value.GetType());
            var valueProperty = contract.Properties.Where(p => p.UnderlyingName == ValuePropertyName).Single();
            // You can simplify this to .Single() if ValueObject<T> has no other properties:
            // var valueProperty = contract.Properties.Single();
            serializer.Serialize(writer, valueProperty.ValueProvider.GetValue(value));
        }
    }
    public static partial class JsonExtensions
    {
        public static JsonReader SkipComments(this JsonReader reader)
        {
            while (reader.TokenType == JsonToken.Comment && reader.Read())
                ;
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
