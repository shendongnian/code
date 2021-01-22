    Bar b = new Bar();
    b.Foo = new CFoo();
    
    using (var s = new System.IO.MemoryStream())
    {
        var bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
        bf.Serialize(s, b);
        s.Position = 0;
        b = (Bar)bf.Deserialize(s);
    
        Console.WriteLine("OK");
    }
