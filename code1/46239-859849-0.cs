    async Task TestWriter(Stream stream) 
    {
        XmlWriterSettings settings = new XmlWriterSettings();
        settings.Async = true;
        using (XmlWriter writer = XmlWriter.Create(stream, settings)) {
            await writer.WriteStartElementAsync("pf", "root", "http://ns");
            await writer.WriteStartElementAsync(null, "sub", null);
            await writer.WriteAttributeStringAsync(null, "att", null, "val");
            await writer.WriteStringAsync("text");
            await writer.WriteEndElementAsync();
            await writer.WriteCommentAsync("cValue");
            await writer.WriteCDataAsync("cdata value");
            await writer.WriteEndElementAsync();
            await writer.FlushAsync();
        }
    }
