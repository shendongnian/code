        var settings = new JsonSerializerSettings
        {
            Formatting = Formatting.Indented,                
        };
        var serializer = JsonSerializer.Create(settings);
        using (var gz = new GZipStream(File.OpenWrite(filespec), CompressionMode.Compress))
        using (var sw = new StreamWriter(gz))
        using (var writer = new JsonTextWriter(sw))
        {
            serializer.Serialize(writer, objectToSerialize);
        }
