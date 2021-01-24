    var person = new Person { Name = "John" };
    XmlAttributeOverrides attributeOverrides = new XmlAttributeOverrides();
    attributeOverrides.Add(typeof(Person), "Name", new XmlAttributes() { XmlDefaultValue = null });
    var serializer = new XmlSerializer(typeof(Person), attributeOverrides);
            
    using (var sw = new StringWriter())
    {
        using (var writer = XmlWriter.Create(sw))
        {
            serializer.Serialize(writer, person);
            var xml = sw.ToString();
        }
    }
