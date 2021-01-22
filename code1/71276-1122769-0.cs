    public void WriteDocument() 
    {
      XmlTextWriter writer = new XmlTextWriter(Console.Out);
      writer.Formatting = Formatting.Indented;
      writer.WriteStartElement("Stock");
      writer.WriteAttributeString("Symbol", symbol);
      writer.WriteElementString("Price", XmlConvert.ToString(price));
      writer.WriteElementString("Change", XmlConvert.ToString(change));
      writer.WriteElementString("Volume", XmlConvert.ToString(volume));
      writer.WriteEndElement();
      writer.Close();
    }
