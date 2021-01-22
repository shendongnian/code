        // Add the customer schema to a new XmlSchemaSet and compile it.
        // Any schema validation warnings and errors encountered reading or 
        // compiling the schema are handled by the ValidationEventHandler delegate.
        XmlSchemaSet schemaSet = new XmlSchemaSet();
        schemaSet.ValidationEventHandler += new ValidationEventHandler(ValidationCallback);
        schemaSet.Add("http://www.w3.org/2001/XMLSchema", "D:\\TMP\\test.xsd");
        schemaSet.Compile();
        // Retrieve the compiled XmlSchema object from the XmlSchemaSet
        // by iterating over the Schemas property.
        XmlSchema customerSchema = null;
        foreach (XmlSchema schema in schemaSet.Schemas())
        {
            customerSchema = schema;
        }
        // Iterate over all schema items
        foreach (object item in xmlSchema.Items)
        {
            if (item is XmlSchemaAttribute)
            {
            }
            else if (item is XmlSchemaComplexType)
            {
            }
            else if (item is XmlSchemaSimpleType)
            {
                XmlSchemaSimpleType simpleType = item as XmlSchemaSimpleType;
                Console.WriteLine("SimpleType found with name=" + simpleType.Name);
            }
            else if (item is XmlSchemaElement)
            {
            }
            else if (item is XmlSchemaAnnotation)
            {
            }
            else if (item is XmlSchemaAttributeGroup)
            {
            }
            else if (item is XmlSchemaNotation)
            {
            }
            else if (item is XmlSchemaGroup)
            {
            }
            else
            {
                Console.WriteLine("Not Implemented.");
            }
        }
