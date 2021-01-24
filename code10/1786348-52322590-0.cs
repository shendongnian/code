    XmlReader reader = XmlReader.Create(path, settings);
    StringBuilder sb = new StringBuilder();
    if (reader != null)
    {                           
        while (reader.Read())
        {
            sb.AppendLine(reader.ReadOuterXml());
        }
        doc = new XmlDocument();
        doc.LoadXml(Convert.ToString(sb));
        XmlNodeList xmlNodeList;
        xmlNodeList = doc.GetElementsByTagName("Whatever your tag name");
        for (i = 0; i < xmlNodeList.Count; i++)
        {
            if (xmlNodeList[i].InnerXml.Length > 0)
            {
                foo = xmlNodeList[i].InnerXml;
            }
        }
    }
