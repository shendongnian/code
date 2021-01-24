    var settings = new XmlReaderSettings();
    settings.DtdProcessing = DtdProcessing.Parse;                        
    using (var reader = XmlReader.Create(new StringReader(yourXml), settings)) {
        // get private field
        var eh = reader.GetType().GetField("entityHandling", BindingFlags.Instance | BindingFlags.NonPublic);
        // prevent expansion of DTD entities, char entities are still expanded
        eh.SetValue(reader, EntityHandling.ExpandCharEntities);
        while (reader.Read()) {
            // do stuff
        }
    }
