    IEnumerable<string> GetKeys(string path)
    {
        using (var reader = new JsonTextReader(File.OpenText(path)))
        {
            while (reader.Read())
            {
                switch (reader.TokenType)
                {
                case JsonToken.PropertyName:
                    yield return (string)reader.Value;
                    reader.Skip(); // skip the value of the property
                    break;
                }
            }
        }
    }
