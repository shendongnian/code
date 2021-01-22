    // Get the assembly that contains the embedded schema
    var assembly = Assembly.GetExecutingAssembly();
    using (var stream = assembly.GetManifestResourceStream("namespace.schema.xsd"))
    using (var reader = XmlReader.Create(stream))
    {
        XmlSchema schema = XMLSchema.Read(
            reader, 
            new ValidationEventHandler(ValidationEventHandler));
    }
