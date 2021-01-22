    void IXmlSerializable.WriteXml(XmlWriter writer)
    {
      if (this._Foo == null)
      {
        writer.WriteStartElement("Foo");
        writer.WriteEndElement("Foo");
      }
      else
      {
        writer.WriteElementString("Foo", this._Foo.ToString());
      }
    }
