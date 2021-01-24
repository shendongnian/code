    using (var reader = new StreamReader(stream))
    using (var jsonReader = new JsonTextReader(reader))
    {
        var vertices = JsonSerializer.CreateDefault().Deserialize<Dictionary<string, VertexData>>(jsonReader);
        var paths = vertices.Keys.ToList();
    }
