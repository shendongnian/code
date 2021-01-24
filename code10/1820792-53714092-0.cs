    foreach (XmlSchemaElement element in customerSchema.Elements.Values)
    {
        Console.WriteLine("Element: {0}", element.Name);
        XmlSchemaComplexType complexType = element.ElementSchemaType as XmlSchemaComplexType;
        XmlSchemaChoice choice = complexType.ContentTypeParticle as XmlSchemaChoice;
        XmlSchemaElement outerElement = choice.Items.Cast<XmlSchemaElement>().First();
        XmlSchemaComplexType innerComplexType = outerElement.ElementSchemaType as XmlSchemaComplexType;
        XmlSchemaSequence xmlSchemaSequence = innerComplexType.ContentTypeParticle as XmlSchemaSequence;
        //// Iterate over each XmlSchemaElement in the Items collection.
        foreach (XmlSchemaElement childElement in xmlSchemaSequence.Items)
        {
            Console.WriteLine("Element: {0}", childElement.Name);
        }
    }
