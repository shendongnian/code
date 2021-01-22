        XmlSchemaSimpleType simpleType = xsdType as XmlSchemaSimpleType;
        Console.WriteLine("simpleType: {0}", xsdType.Name);
        XmlSchemaSimpleTypeRestriction restriction = simpleType.Content as XmlSchemaSimpleTypeRestriction;
        if (restriction != null)
        {
            Console.WriteLine("restriction : {0}", restriction.BaseTypeName.Name);
            foreach (XmlSchemaObject facet in restriction.Facets)
            {
                if (facet is XmlSchemaEnumerationFacet)
                Console.WriteLine("Element: {0}", ((XmlSchemaEnumerationFacet)facet).Value);
            }
        }
