    public static void Deserialize(this List<string> list, string fileName)
    {
        XmlRootAttribute xmlRoot = new XmlRootAttribute();
        xmlRoot.ElementName = "YourRootElementName";
        xmlRoot.IsNullable = true;
    
        var serializer = new XmlSerializer(typeof(List<string>), xmlRoot);
        using (var stream = File.OpenRead(fileName))
        {
            var other = (List<string>)(serializer.Deserialize(stream));
            list.Clear();
            list.AddRange(other);
        }
    }
