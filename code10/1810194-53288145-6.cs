    var stringWriter = new StringWriter();
    using (var writer = new JsonTextWriter(stringWriter))
    {
        writer.QuoteName = false;
        writer.Formatting = Formatting.Indented;
        writer.Indentation = 0;
        JsonSerializer.CreateDefault(settings).Serialize(writer, obj);
    }
