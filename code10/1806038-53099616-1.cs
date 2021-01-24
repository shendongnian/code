    private static Payload DeserializePayload(JToken token)
    {
        var serializer = new JsonSerializer();
        using (JsonTextReader reader = new JsonTextReader(new StringReader(token.ToString())))
        {
            reader.CloseInput = true;
            while (reader.Read())
            {
                if (reader.TokenType == JsonToken.StartObject && reader.Path.Equals("payload"))
                {
                    var payload = serializer.Deserialize<Payload>(reader);
                    return payload;
                }
            }
        }
        // not found - return null? throw exception?
        return null;
    }
