    config.Formatters.Clear();
    config.Formatters.Add(new JsonMediaTypeFormatter() {
        SerializerSettings = new JsonSerializerSettings {
            Formatting = Formatting.Indented
        }
    };
