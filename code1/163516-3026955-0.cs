    writer.WriteStartElement("CocoKeys");
    foreach (var kvp in coco)
    {
      writer.WriteStartElement("CocoKey");
      writer.WriteAttributeString("key", kvp.Key);
      writer.WriteStartElement("CoCoValues");
      foreach(string s in kvp.Value)
      {
        writer.WriteStartElement("CoCoValue");
        writer.WriteString(s);
        writer.WriteEndElement();
      }
      writer.WriteEndElement();
      writer.WriteEndElement();
      writer.WriteEndElement();
    }
