    internal class WhatToMineCalculatorResponseListConverter : KeyedListToJsonObjectConverterBase<WhatToMineCalculatorResponse>
    {
        protected override string KeyPropertyUnderlyingName => nameof(WhatToMineCalculatorResponse.Name);
    }
    public abstract class KeyedListToJsonObjectConverterBase<T> : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            if (objectType.IsArray)
                return false;
            return typeof(IList<T>).IsAssignableFrom(objectType);
        }
        protected abstract string KeyPropertyUnderlyingName { get; }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            // Get the key property name from the underlying name
            var itemContract = serializer.ContractResolver.ResolveContract(typeof(T)) as JsonObjectContract;
            if (itemContract == null)
                throw new JsonSerializationException(string.Format("type {0} is not serialized as a JSON object"));
            var keyProperty = itemContract.Properties.Where(p => p.UnderlyingName == KeyPropertyUnderlyingName).SingleOrDefault();
            if (keyProperty == null)
                throw new JsonSerializationException(string.Format("Key property {0} not found", KeyPropertyUnderlyingName));
            // Validate initial token.
            if (reader.SkipComments().TokenType == JsonToken.Null)
                return null;
            if (reader.TokenType != JsonToken.StartObject)
                throw new JsonSerializationException(string.Format("Unexpected token {0} at {1}", reader.TokenType, reader.Path));
            // Allocate the List<T>.  (It might be some subclass of List<T>, so use the default creator.
            var list = existingValue as ICollection<T> ?? (ICollection<T>)serializer.ContractResolver.ResolveContract(objectType).DefaultCreator();
            // Process each key/value pair.
            while (reader.Read())
            {
                switch (reader.TokenType)
                {
                    case JsonToken.Comment:
                        break;
                    case JsonToken.EndObject:
                        return list;
                    case JsonToken.PropertyName:
                        {
                            // Get the name.
                            var name = (string)reader.Value;
                            reader.ReadAndAssert();
                            // Load the object
                            var jItem = JObject.Load(reader);
                            // Add the name property
                            jItem.Add(keyProperty.PropertyName, name);
                            // Deserialize the item and add it to the list.
                            list.Add(jItem.ToObject<T>(serializer));
                        }
                        break;
                    default:
                        {
                            throw new JsonSerializationException(string.Format("Unexpected token {0} at {1}", reader.TokenType, reader.Path));
                        }
                }
            }
            // Should not come here.
            throw new JsonSerializationException("Unclosed object at path: " + reader.Path);
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            // Get the key property name from the underlying name
            var itemContract = serializer.ContractResolver.ResolveContract(typeof(T)) as JsonObjectContract;
            if (itemContract == null)
                throw new JsonSerializationException(string.Format("type {0} is not serialized as a JSON object"));
            var keyProperty = itemContract.Properties.Where(p => p.UnderlyingName == KeyPropertyUnderlyingName).SingleOrDefault();
            if (keyProperty == null)
                throw new JsonSerializationException(string.Format("Key property {0} not found", KeyPropertyUnderlyingName));
            var converters = serializer.Converters.ToArray();
            var list = (IEnumerable<T>)value;
            writer.WriteStartObject();
            foreach (var item in list)
            {
                var jItem = JObject.FromObject(item, serializer);
                var name = (string)jItem[keyProperty.PropertyName];
                jItem.Remove(keyProperty.PropertyName);
                writer.WritePropertyName(name);
                jItem.WriteTo(writer, converters);
            }
            writer.WriteEndObject();
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
        public static void ReadAndAssert(this JsonReader reader)
        {
            if (reader == null)
                throw new ArgumentNullException();
            if (!reader.Read())
            {
                new JsonReaderException(string.Format("Unexpected end at path {0}", reader.Path));
            }
        }
    }
