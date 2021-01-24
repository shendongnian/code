    public class TolerantDictionaryItemConverter<TDictionary, TValue> : JsonConverter where TDictionary : IDictionary<string, TValue>
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(TDictionary).IsAssignableFrom(objectType);
        }
        public override object ReadJson(JsonReader reader, Type dictionaryType, object existingValue, JsonSerializer serializer)
        {
            // Get contract information
            var contract = serializer.ContractResolver.ResolveContract(dictionaryType) as JsonDictionaryContract;
            if (contract == null)
                throw new JsonSerializationException(string.Format("Invalid JsonDictionaryContract for {0}", dictionaryType));
            if (contract.DictionaryKeyType != typeof(string))
                throw new JsonSerializationException(string.Format("Key type {0} not supported", dictionaryType));
            var itemContract = serializer.ContractResolver.ResolveContract(contract.DictionaryValueType);
            // Process the first token
            var tokenType = reader.SkipComments().TokenType;
            if (tokenType == JsonToken.Null)
                return null;
            if (reader.TokenType != JsonToken.StartObject)
                throw new JsonSerializationException(string.Format("Expected {0}, encountered {1} at path {2}", JsonToken.StartArray, reader.TokenType, reader.Path));
            // Allocate the dictionary
            var dictionary = existingValue as IDictionary<string, TValue> ?? (IDictionary<string, TValue>) contract.DefaultCreator();
            // Process the collection items
            while (reader.Read())
            {
                if (reader.TokenType == JsonToken.EndObject)
                {
                    return dictionary;
                }
                else if (reader.TokenType == JsonToken.PropertyName)
                {
                    var key = (string)reader.Value;
                    reader.ReadSkipCommentsAndAssert();
                    // For performance, skip tokens we can easily determine cannot be deserialized to itemContract
                    if (itemContract.QuickRejectStartToken(reader.TokenType))
                    {
                        System.Diagnostics.Debug.WriteLine(string.Format("value for {0} skipped", key));
                        reader.Skip();
                    }
                    else
                    {
                        // What we want to do is to distinguish between JSON files that are not WELL-FORMED
                        // (e.g. truncated) and that are not VALID (cannot be deserialized to the current item type).
                        // An exception must still be thrown for an ill-formed file.
                        // Thus we first load into a JToken, then deserialize.
                        var token = JToken.Load(reader);
                        try
                        {
                            var value = serializer.Deserialize<TValue>(token.CreateReader());
                            dictionary.Add(key, value);
                        }
                        catch (Exception)
                        {
                            System.Diagnostics.Debug.WriteLine(string.Format("value for {0} skipped", key));
                        }
                    }
                }
                else if (reader.TokenType == JsonToken.Comment)
                {
                    continue;
                }
                else
                {
                    throw new JsonSerializationException(string.Format("Unexpected token type {0} object at path {1}.", reader.TokenType, reader.Path));
                }
            }
            // Should not come here.
            throw new JsonSerializationException("Unclosed object at path: " + reader.Path);
        }
        public override bool CanWrite { get { return false; } }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
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
        public static void ReadSkipCommentsAndAssert(this JsonReader reader)
        {
            if (reader == null)
                throw new ArgumentNullException();
            while (reader.Read())
            {
                if (reader.TokenType != JsonToken.Comment)
                    return;
            }
            new JsonReaderException(string.Format("Unexpected end at path {0}", reader.Path));
        }
        internal static bool QuickRejectStartToken(this JsonContract contract, JsonToken token)
        {
            if (contract is JsonLinqContract)
                return false;
            switch (token)
            {
                case JsonToken.None:
                    return true;
                case JsonToken.StartObject:
                    return !(contract is JsonContainerContract) || contract is JsonArrayContract; // reject if not dictionary or object
                case JsonToken.StartArray:
                    return !(contract is JsonArrayContract); // reject if not array
                case JsonToken.Null:
                    return contract.CreatedType.IsValueType && Nullable.GetUnderlyingType(contract.UnderlyingType) == null;
                // Primitives
                case JsonToken.Integer:
                case JsonToken.Float:
                case JsonToken.String:
                case JsonToken.Boolean:
                case JsonToken.Undefined:
                case JsonToken.Date:
                case JsonToken.Bytes:
                    return !(contract is JsonPrimitiveContract); // reject if not primitive.
                default:
                    return false;
            }
        }
    }
