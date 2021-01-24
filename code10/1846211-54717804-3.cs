    public static partial class JsonExtensions
    {
        public static int ValueAsInt32(this JsonReader reader)
        {
            if (reader == null)
                throw new ArgumentNullException();
            if (reader.TokenType != JsonToken.Integer)
                throw new JsonSerializationException("Value is not Int32");
            try
            {
                return Convert.ToInt32(reader.Value, NumberFormatInfo.InvariantInfo);
            }
            catch (Exception ex)
            {
                // Wrap the system exception in a serialization exception.
                throw new JsonSerializationException(string.Format("Invalid integer value {0}", reader.Value), ex);
            }
        }
        public static JsonReader ReadToContentAndAssert(this JsonReader reader)
        {
            if (reader == null)
                throw new ArgumentNullException();
            while (reader.Read())
            {
                if (reader.TokenType != JsonToken.Comment)
                    return reader;
            }
            throw new JsonReaderException(string.Format("Unexpected end at path {0}", reader.Path));
        }
        public static JsonReader MoveToContent(this JsonReader reader)
        {
            if (reader == null)
                throw new ArgumentNullException();
            if (reader.TokenType == JsonToken.None)
                if (!reader.Read())
                    return reader;
            while (reader.TokenType == JsonToken.Comment && reader.Read())
                ;
            return reader;
        }
    }
