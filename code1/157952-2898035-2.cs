    XmlSchema schema = XmlSchema.Read(XmlReader.Create("v1.xsd"), 
        new ValidationEventHandler(ValidationCallbackOne));
    XmlSchemaSet schemaSet = new XmlSchemaSet();
    schemaSet.Add(schema);
    schemaSet.Compile();
    
    IEnumerable<string> enumeratedValues = schema.Items.OfType<XmlSchemaSimpleType>()
        .Where(s => (s.Content is XmlSchemaSimpleTypeRestriction) 
            && s.Name == "Type")
        .SelectMany<XmlSchemaSimpleType, string>
            (c =>((XmlSchemaSimpleTypeRestriction)c.Content)
                .Facets.OfType<XmlSchemaEnumerationFacet>().Select(d=>d.Value));
    
    // will output Op1, Op2, Op3...
    foreach (string s in enumeratedValues)
    {
        Console.WriteLine(s);
    }
