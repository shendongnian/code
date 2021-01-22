    public static void AddElementToSchema(XmlSchema xmlSchema, string elementName, string elementType, string xmlNamespace)
    {
        XmlSchemaElement testNode = new XmlSchemaElement();
        testNode.Name = elementName;
        testNode.Namespaces.Add("", xmlNamespace);
        testNode.SchemaTypeName = new XmlQualifiedName(elementType, xmlNamespace);
        xmlSchema.Items.Add(testNode);
        xmlSchema.Compile(XMLValidationEventHandler);
    }
