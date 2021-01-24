    using (StreamWriter sw = new StreamWriter(stream))  // or StringWriter if you prefer
    using (JsonWriter writer = new JsonTextWriter(sw))
    {
        writer.Formatting = Formatting.Indented;
        input.RedactedWriteTo(writer);
    }
