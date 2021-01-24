    using (var reader = new StreamReader(stream))
    {
        var jsonString = reader.ReadToEnd();
        var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
        var vertices = serializer.Deserialize<Dictionary<string, VertexData>>(jsonString);
        var paths = vertices.Keys.ToList();
    }
