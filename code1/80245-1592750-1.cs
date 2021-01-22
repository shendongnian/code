            try
            {
                XmlReaderSettings Xsettings = new XmlReaderSettings();
                Xsettings.Schemas.Add(null, "personDivideSchema.xsd");
                Xsettings.ValidationType = ValidationType.Schema;
                
                XmlDocument document = new XmlDocument();
                document.Load("person.xml");
                XmlReader reader = XmlReader.Create(new StringReader(document.InnerXml), Xsettings);
                while (reader.Read());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message.ToString());
            }
