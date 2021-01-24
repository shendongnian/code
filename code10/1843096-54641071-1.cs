    public static partial class JsonExtensions
    {
        public static IEnumerable<T> DeserializeArrayItems<T>(this JsonSerializer serializer, JsonReader reader)
        {
            if (reader.MoveToContent().TokenType == JsonToken.Null)
                yield break;
            if (reader.TokenType != JsonToken.StartArray)
                throw new JsonSerializationException(string.Format("Current token {0} is not an array at path {1}", reader.TokenType, reader.Path));
            // Process the collection items
            while (reader.Read())
            {
                switch (reader.TokenType)
                {
                    case JsonToken.EndArray:
                        yield break;
                    case JsonToken.Comment:
                        break;
                    default:
                        yield return serializer.Deserialize<T>(reader);
                        break;
                }
            }
            // Should not come here.
            throw new JsonReaderException(string.Format("Unclosed array at path {0}", reader.Path));
        }
        public static JsonReader MoveToContent(this JsonReader reader)
        {
            if (reader.TokenType == JsonToken.None)
                reader.Read();
            while (reader.TokenType == JsonToken.Comment && reader.Read())
                ;
            return reader;
        }
    }
