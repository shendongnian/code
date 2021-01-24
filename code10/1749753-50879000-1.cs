    var serializer = new Serializer(); //YamlDotNet.Serialization.Serializer
    using (var fs = File.OpenWrite("some/path.yaml"))
    using (var sw = new StreamWriter(fs))
    {
        serializer.Serialize(sw, doc.RootNode);
    }
