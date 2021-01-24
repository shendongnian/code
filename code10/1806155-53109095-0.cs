    private static IEnumerable<KeyValuePair<string, string>> ParseKeyValuePairs(string json)
    {
        using (var reader = new StringReader(json))
        using (var jsonReader = new JsonTextReader(reader) { SupportMultipleContent = true })
        {
            JsonSerializer serializer = JsonSerializer.CreateDefault();
            while (jsonReader.Read())
            {
                if (jsonReader.TokenType == JsonToken.Comment)
                {
                    continue;
                }
                var dictionaries = serializer.Deserialize<List<Dictionary<string, string>>>(jsonReader);
                foreach (KeyValuePair<string, string> keyValue in dictionaries.SelectMany(x => x))
                {
                    yield return keyValue;
                }
            }
        }
    }
