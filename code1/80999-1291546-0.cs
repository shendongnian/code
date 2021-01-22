    void IXmlSerializable.WriteXml(XmlWriter writer)
    {
        ...
        if (this._PropName == null)
        {
            writer.WriteStartElement("PropName");
            writer.WriteAttributeString("xsi", "nil", "http://www.w3.org/2001/XMLSchema-instance", "true");
            writer.WriteEndElement();
        }
        else
        {
            writer.WriteElementString("PropName", this._PropName.ToString());
        }
        ...
    }
