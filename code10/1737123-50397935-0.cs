    Dip dipConfig = null;
    var xmlString = File.ReadAllText(@"DipConfig.xml");
    using (var stream = new StringReader(xmlString))
    {
        var serializer = new XmlSerializer(typeof(Dip));
        dipConfig = (Dip)serializer.Deserialize(stream);
    }
    foreach (var version in dipConfig.Versions.Version)
    {
        Console.WriteLine(version.Number);
        foreach (var fieldType in version.Orderedfields.Type)
        {
            Console.WriteLine(fieldType);
        }
    }
    
