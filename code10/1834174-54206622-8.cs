    public abstract class JsonListItemTypeInferringConverterBase<TItem> : JsonConverter
    {
        public override bool CanWrite { get { return false; } }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        protected abstract bool TryInferItemType(Type objectType, JToken json, out Type type);
        protected virtual object CreateObject(Type actualType, JsonSerializer serializer, JObject json)
        {
            var contract = (JsonObjectContract)serializer.ContractResolver.ResolveContract(actualType);
            return contract.DefaultCreator();
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            // Get contract information
            var contract = serializer.ContractResolver.ResolveContract(objectType) as JsonArrayContract;
            if (contract == null || contract.IsMultidimensionalArray || objectType.IsArray)
                throw new JsonSerializationException(string.Format("Invalid array contract for {0}", objectType));
            if (reader.MoveToContent().TokenType == JsonToken.Null)
                return null;
            if (reader.TokenType != JsonToken.StartArray)
                throw new JsonSerializationException(string.Format("Expected {0}, encountered {1} at path {2}", JsonToken.StartArray, reader.TokenType, reader.Path));
            var collection = existingValue as IList<TItem> ?? (IList<TItem>)contract.DefaultCreator();
            // Process the collection items
            while (reader.Read())
            {
                switch (reader.TokenType)
                {
                    case JsonToken.EndArray:
                        return collection;
                    case JsonToken.Comment:
                        break;
                    default:
                        {
                            var token = JToken.Load(reader);
                            Type itemType;
                            if (!TryInferItemType(typeof(TItem), token, out itemType))
                                break;
                            collection.Add((TItem)serializer.Deserialize(token.CreateReader(), itemType));
                        }
                        break;
                }
            }
            // Should not come here.
            throw new JsonSerializationException("Unclosed array at path: " + reader.Path);
        }
        public override bool CanConvert(Type objectType)
        {
            return objectType.IsAssignableFrom(typeof(List<TItem>));
        }
    }
    public static partial class JsonExtensions
    {
        public static JsonReader MoveToContent(this JsonReader reader)
        {
            while ((reader.TokenType == JsonToken.Comment || reader.TokenType == JsonToken.None) && reader.Read())
                ;
            return reader;
        }
    }
