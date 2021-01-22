    var lookup = new Dictionary<int, string>();
    lookup.Add(1, "123");
    lookup.Add(2, "456");
    using (var ms = new MemoryStream())
    {
        var formatter = 
           new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
        formatter.Serialize(ms, lookup);
        lookup = null;
        ms.Position = 0;
        lookup = (Dictionary<int, string>) formatter.Deserialize(ms);
    }
    foreach(var i in lookup.Keys)
    {
        Console.WriteLine("{0}: {1}", i, lookup[i]);
    }
