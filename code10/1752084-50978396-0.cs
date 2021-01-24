    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        if (reader.TokenType == JsonToken.String && (reader.Value as string == ""))
            return null;
        skip = true;
        return serializer.Deserialize(reader, objectType);
    }
    private bool skip = false;
    public override bool CanConvert(Type objectType) // If this is ever cached, this hack won't work.
    {
        if (skip)
        {
            skip = false;
            return false;
        }
        return true;
    }
