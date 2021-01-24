    private static IEnumerable<string> GetTerms(string json)
    {
        using (JsonTextReader reader = new JsonTextReader(new StringReader(json)))
        {
            while (reader.Read())
            {
                if (reader.TokenType == JsonToken.PropertyName && reader.Value.Equals("term"))
                {
                    string term = reader.ReadAsString();
                    yield return term;
                }
            }
        }
    }
