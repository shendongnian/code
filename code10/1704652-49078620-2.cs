    public class TolerantObjectCollectionConverter<TItem> : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return !objectType.IsArray && objectType != typeof(string) && typeof(ICollection<TItem>).IsAssignableFrom(objectType);
        }
        public override bool CanWrite { get { return false; } }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            // Get contract information
            var contract = serializer.ContractResolver.ResolveContract(objectType) as JsonArrayContract;
            if (contract == null || contract.IsMultidimensionalArray || objectType.IsArray)
                throw new JsonSerializationException(string.Format("Invalid array contract for {0}", objectType));
            // Process the first token
            var tokenType = reader.SkipComments().TokenType;
            if (tokenType == JsonToken.Null)
                return null;
            if (tokenType != JsonToken.StartArray)
                throw new JsonSerializationException(string.Format("Expected {0}, encountered {1} at path {2}", JsonToken.StartArray, reader.TokenType, reader.Path));
            // Allocate the collection
            var collection = existingValue as ICollection<TItem> ?? (ICollection<TItem>)contract.DefaultCreator();
            // Process the collection items
            while (reader.Read())
            {
                switch (reader.TokenType)
                {
                    case JsonToken.EndArray:
                        return collection;
                    case JsonToken.StartObject:
                    case JsonToken.Null:
                        collection.Add(serializer.Deserialize<TItem>(reader));
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }
            // Should not come here.
            throw new JsonSerializationException("Unclosed array at path: " + reader.Path);
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
