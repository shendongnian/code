    private static IEnumerable<long> GetReviewerIds(string path)
    {
        using (StreamReader streamReader = File.OpenText(path))
        using (JsonTextReader reader = new JsonTextReader(streamReader))
        {
            reader.CloseInput = true;
            while (reader.Read())
            {
                if (reader.TokenType == JsonToken.PropertyName && reader.Value.Equals("Reviewer"))
                {
                    int? id = reader.ReadAsInt32();
                    if (id.HasValue)
                    {
                        yield return id.Value;
                    }
                }
            }
        }
    }
