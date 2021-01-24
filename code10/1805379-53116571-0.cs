    using (FileStream s = File.Open("big.json")) // or any other stream
    using (StreamReader streamReader = new StreamReader(s))
    using (JsonTextReader reader = new JsonTextReader(streamReader))
    {
        reader.SupportMultipleContent = true;
        int rowCount = 0;
        var serializer = new JsonSerializer();
        while (reader.Read())
        {
            if (reader.TokenType == JsonToken.StartObject)
            {
                DataRow r = serializer.Deserialize<Contact>(reader);
                rowCount++;
            }
        }
    }
