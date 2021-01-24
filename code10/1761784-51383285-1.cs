    XmlAttributeOverrides attributeOverrides = new XmlAttributeOverrides();
    var attributes = new XmlAttributes()
    {
        XmlDefaultValue = null,
        XmlAttribute = new XmlAttributeAttribute()
    };
    attributeOverrides.Add(typeof(Person), "Name", attributes);
    var serializer = new XmlSerializer(typeof(Person), attributeOverrides);
    var person = new Person { Name = "John" };
    using (var sw = new StringWriter())
    {
        using (var writer = XmlWriter.Create(sw))
        {
            serializer.Serialize(writer, person);
            var xml = sw.ToString();
        }
    }
