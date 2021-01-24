    private static IEnumerable<int> GetIds(JRaw raw)
    {
        using (var stringReader = new StringReader(raw.Value.ToString()))
        using (var textReader = new JsonTextReader(stringReader))
        {
            while (textReader.Read())
            {
                if (textReader.TokenType == JsonToken.PropertyName && textReader.Value.Equals("id"))
                {
                    int? id = textReader.ReadAsInt32();
                    if (id.HasValue)
                    {
                        yield return id.Value;
                    }
                }
            }
        }
    }
