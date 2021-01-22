    ...
    XmlSerializer s = new XmlSerializer(objectToSerialize.GetType());
    XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
    ns.Add("","");
    s.Serialize(xmlWriter, objectToSerialize, ns);
