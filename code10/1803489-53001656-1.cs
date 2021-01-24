    IEnumerable<string> GetKeys(string path)
    {
        using (var reader = new JsonTextReader(File.OpenText(path)))
        {
            while (reader.Read())
            {
                switch (reader.TokenType)
                {
                case JsonToken.PropertyName:
                    if ((string)reader.Value == "Diagnoses") // only interested in "Diagnoses" property
                    {
                        foreach (var key in _GetKeys(reader))
                            yield return key;
                        yield break;
                    }
                    reader.Skip();
                    break;
                }
            }
        }
    
        IEnumerable<string> _GetKeys(JsonReader reader)
        {
            while (reader.Read())
            {
                switch (reader.TokenType)
                {
                case JsonToken.PropertyName:
                    yield return (string)reader.Value;
                    reader.Skip(); // skip the value of the property
                    break;
                case JsonToken.EndObject:
                    yield break;
                }
            }
        }
    }
