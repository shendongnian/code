    public static void ConvertJson(TextReader textReader, TextWriter textWriter, 
                                   NamingStrategy strategy, 
                                   Formatting formatting = Formatting.Indented)
    {
        using (JsonReader reader = new JsonTextReader(textReader))
        using (JsonWriter writer = new JsonTextWriter(textWriter))
        {
            writer.Formatting = formatting;
            if (reader.TokenType == JsonToken.None)
            {
                reader.Read();
                ConvertJsonValue(reader, writer, strategy);
            }
        }
    }
    private static void ConvertJsonValue(JsonReader reader, JsonWriter writer, 
                                         NamingStrategy strategy)
    {
        if (reader.TokenType == JsonToken.StartObject)
        {
            writer.WriteStartObject();
            while (reader.Read() && reader.TokenType != JsonToken.EndObject)
            {
                string name = strategy.GetPropertyName((string)reader.Value, false);
                writer.WritePropertyName(name);
                reader.Read();
                ConvertJsonValue(reader, writer, strategy);
            }
            writer.WriteEndObject();
        }
        else if (reader.TokenType == JsonToken.StartArray)
        {
            writer.WriteStartArray();
            while (reader.Read() && reader.TokenType != JsonToken.EndArray)
            {
                ConvertJsonValue(reader, writer, strategy);
            }
            writer.WriteEndArray();
        }
        else if (reader.TokenType == JsonToken.Integer)
        {
            // convert integer values to string
            writer.WriteValue(Convert.ToString((long)reader.Value));
        }
        else if (reader.TokenType == JsonToken.Float)
        {
            // convert floating point values to string
            writer.WriteValue(Convert.ToString((double)reader.Value,
                              System.Globalization.CultureInfo.InvariantCulture));        
        }
        else // string, bool, date, etc.
        {
            writer.WriteValue(reader.Value);
        }
    }
