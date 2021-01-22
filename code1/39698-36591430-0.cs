    XmlSerializer sr = new XmlSerializer(objectToSerialize.GetType());
    TextWriter xmlWriter = new StreamWriter(filename);
    XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
    namespaces.Add(string.Empty, string.Empty);
    sr.Serialize(xmlWriter, objectToSerialize, namespaces);
    
          
