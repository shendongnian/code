    void LoadSlots()
    {
      XmlDocument doc = new XmlDocument();
      doc.Load(Environment.CurrentDirectory + "\\queue.xml");
      XmlNodeList nodes = doc.SelectNodes("//queue/slots/slot");
      foreach (XmlNode node in nodes)
      {
        string filename = node.Attributes["filename"].InnerText;
        string size = node.Attributes["size"].InnerText;
        string status = node.Attributes["status"].InnerText;
        _slots.Add(filename, size, status);
      }
    }
