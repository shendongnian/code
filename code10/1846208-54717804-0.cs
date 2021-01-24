    public class RangeOrValueConverter : JsonConverter
    {
        const string MinName = "Min";
        const string MaxName = "Max";
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(RangeOrValue) || Nullable.GetUnderlyingType(objectType) == typeof(RangeOrValue);
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var range = (RangeOrValue)value;
            if (range.IsRange)
            {
                // Range values are stored as objects
                writer.WriteStartObject();
                writer.WritePropertyName(MinName);
                writer.WriteValue(range.Min);
                writer.WritePropertyName(MaxName);
                writer.WriteValue(range.Max);
                writer.WriteEndObject();
            }
            else
            {
                writer.WriteValue(range.Value);
            }
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            switch (reader.MoveToContent().TokenType)
            {
                case JsonToken.Null:
                    // nullable RangeOrValue; return null.
                    return null;  
                case JsonToken.Integer:
                    return new RangeOrValue(reader.ValueAsInt32());
                case JsonToken.StartObject:
                    int? min = null;
                    int? max = null;
                    var done = false;
                    while (!done)
                    {
                        // Read the next token skipping comments if any
                        switch (reader.ReadToContentAndAssert().TokenType)
                        {
                            case JsonToken.PropertyName:
                                var name = (string)reader.Value;
                                if (name.Equals(MinName, StringComparison.OrdinalIgnoreCase))
                                    // ReadAsInt32() reads the NEXT token as an Int32, thus advancing past the property name.
                                    min = reader.ReadAsInt32();
                                else if (name.Equals(MaxName, StringComparison.OrdinalIgnoreCase))
                                    max = reader.ReadAsInt32();
                                else
                                    // Unknown property name.  Skip past it and its value.
                                    reader.ReadToContentAndAssert().Skip();
                                break;
                            case JsonToken.EndObject:
                                done = true;
                                break;
                            default:
                                throw new JsonSerializationException(string.Format("Invalid token type {0} at path {1}", reader.TokenType, reader.Path));
                        }
                    }
                    if (max != null && min != null)
                        return new RangeOrValue(min.Value, max.Value);
                    throw new JsonSerializationException(string.Format("Missing min or max at path {0}", reader.Path));
                default:
                    throw new JsonSerializationException(string.Format("Invalid token type {0} at path {1}", reader.TokenType, reader.Path));
            }
        }
    }
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
