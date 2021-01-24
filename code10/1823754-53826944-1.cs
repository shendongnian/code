    using (StreamReader streamReader = new StreamReader(val))
    using (JsonTextReader reader = new JsonTextReader(streamReader))
    {
        reader.SupportMultipleContent = true;
        var serializer = new JsonSerializer();
        while (reader.Read())
        {
            if (reader.TokenType == JsonToken.StartObject)
            {
                var data = serializer.Deserialize<Data>(reader);
                //data.locations etc etc..
            }
        }
    }
