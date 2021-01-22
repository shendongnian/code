        using System.Xml;
        using System.Xml.Schema;
        public static bool Validate(string schemaPath, string documentPath, out List<ValidationEventArgs> eventsOut)
        {
            XmlReader schemaReader = XmlReader.Create(schemaPath);
            XmlSchemaSet schemaSet = new XmlSchemaSet();
            schemaSet.Add(XmlSchema.Read(schemaReader, new ValidationEventHandler(
            delegate(Object sender, ValidationEventArgs e)
            {
            }    
            )));
            List<ValidationEventArgs> events = new List<ValidationEventArgs>();
            schemaReader.Close();
            XmlDocument d = new XmlDocument();
            d.Schemas = schemaSet;
            d.Load(documentPath);
            d.Validate(new ValidationEventHandler(
                delegate(Object sender, ValidationEventArgs e)
                {
                    events.Add(e);
                }
            ));
            eventsOut = events;
            if (events.Count > 0)
                return false;
            return true; 
        }
