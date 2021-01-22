        XmlSchema schema = XmlSchema.Read(XmlReader.Create("v1.xsd"), 
            new ValidationEventHandler(ValidationCallbackOne));                
        schema.Compile(new ValidationEventHandler(ValidationCallbackOne));
        foreach (XmlSchemaObject obj in schema.Items)
        {
            if (obj is XmlSchemaSimpleType)
            {
                XmlSchemaSimpleType so = (XmlSchemaSimpleType)obj;
                Console.WriteLine(so.Name);
                Console.WriteLine(so.Content.GetType().Name);
                
                if (so.Content is XmlSchemaSimpleTypeRestriction)
                {
                    XmlSchemaSimpleTypeRestriction sr = (XmlSchemaSimpleTypeRestriction)so.Content;
                    foreach (XmlSchemaEnumerationFacet en in sr.Facets.OfType<XmlSchemaEnumerationFacet>())
                    {
                        Console.WriteLine(en.Value);                            
                    }
                }
            }
        }
