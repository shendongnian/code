    XmlSchemaElement root = _schema.Items[0] as XmlSchemaElement;
    XmlSchemaSequence children = ((XmlSchemaComplexType)root.ElementSchemaType).ContentTypeParticle as XmlSchemaSequence;
    foreach(XmlSchemaObject child in children.Items.OfType<XmlSchemaElement>()) {
        XmlSchemaComplexType type = child.ElementSchemaType as XmlSchemaComplexType;
        if(type == null) {
            // It's a simple type, no sub-elements.
        } else {
            if(type.Attributes.Count > 0) {
                // Handle declared attributes -- use type.AttributeUsers for inherited ones
            }
            XmlSchemaSequence grandchildren = type.ContentTypeParticle as XmlSchemaSequence;
            if(grandchildren != null) {
                foreach(XmlSchemaObject xso in grandchildren.Items) {
                    if(xso.GetType().Equals(typeof(XmlSchemaElement))) {
                        // Do something with an element.
                    } else if(xso.GetType().Equals(typeof(XmlSchemaSequence))) {
                        // Iterate across the sequence.
                    } else if(xso.GetType().Equals(typeof(XmlSchemaAny))) {
                        // Good luck with this one!
                    } else if(xso.GetType().Equals(typeof(XmlSchemaChoice))) {
                        foreach(XmlSchemaObject o in ((XmlSchemaChoice)xso).Items) {
                            // Rinse, repeat...
                        }
                    }
                }
            }
        }
    }
