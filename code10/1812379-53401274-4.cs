    var root = new double[,,] { { { 1 } } };
    var settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Arrays };
    var json = JsonConvert.SerializeObject(root, Formatting.Indented, settings);
    // Try to deserialize to the same type as root
    // but get an exception instead:
    var root2 = JsonConvert.DeserializeAnonymousType(json, root, settings);
