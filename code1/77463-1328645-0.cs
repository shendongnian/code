    class ContainingClass : IXmlSerializable
    {
     ...
     
    #region IXmlSerializable Members
    public XmlSchema GetSchema()
    {
      return null;
    }
    public void ReadXml(XmlReader reader)
    {
      **reader.ReadStartElement("Equipment");**
      XmlSerializer ser = new XmlSerializer(typeof(Host));
      while (reader.NodeType != XmlNodeType.EndElement)
      {
        Host newHost = new Host();
        newHost.Name = (string) ser.Deserialize(reader);
        _hosts.Add(newHost);
        reader.Read();
      }
      // Read the node to its end.
      // Next call of the reader methods will crash if not called.
      **reader.ReadEndElement(); // "Equipment"**
    }
    public void WriteXml(XmlWriter writer)
    {
      XmlSerializer ser = new XmlSerializer(typeof(Host));
      **writer.WriteStartElement("Equipment");**
      foreach (Host host in this._hosts)
      {
        ser.Serialize(writer, host);
      }
      **writer.WriteEndElement();**
    }
    #endregion
