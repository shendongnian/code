    using System.Collections.Specialized;
    public class StringDictionaryConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(StringDictionary).IsAssignableFrom(objectType);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var tokenType = reader.SkipComments().TokenType;
            if (tokenType == JsonToken.Null)
                return null;
            var dictionary = existingValue as StringDictionary ?? (StringDictionary)serializer.ContractResolver.ResolveContract(objectType).DefaultCreator();
            switch (tokenType)
            {
                case JsonToken.StartArray:
                    {
                        // StringDictionary serialized without converter
                        var list = serializer.Deserialize<List<KeyValuePair<string, string>>>(reader);
                        foreach (var pair in list)
                            dictionary.Add(pair.Key, pair.Value);
                    }
                    break;
                case JsonToken.StartObject:
                    {
                        // StringDictionary serialized with converter
                        var typedDictionary = serializer.Deserialize<Dictionary<string, string>>(reader);
                        foreach (var pair in typedDictionary)
                            dictionary.Add(pair.Key, pair.Value);
                    }
                    break;
                default:
                    throw new JsonSerializationException(string.Format("Unknown token {0} at path {1}", tokenType, reader.Path));
            }
            return dictionary;
        }
        // Change to false if you want the dictionary written as an array of key/value objects.
        public override bool CanWrite { get { return true; } }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var dictionary = (StringDictionary)value;
            writer.WriteStartObject();
            foreach (DictionaryEntry entry in dictionary)
            {
                writer.WritePropertyName((string)entry.Key);
                writer.WriteValue((string)entry.Value);
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
    }
