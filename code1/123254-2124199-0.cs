    class Program
    {
        static void Main()
        {
            var settings = new XmlReaderSettings();
            settings.ProhibitDtd = false;
            using (var reader = XmlReader.Create("XMLSchema.xsd", settings))
            {
                settings.Schemas.Add(XmlSchema.Read(reader, null));
            }
            using (var reader = XmlReader.Create("xsd.xsd", settings))
            {
                // This will throw if the XML file is not valid
                while (reader.Read()) ;
            }
        }
    }
