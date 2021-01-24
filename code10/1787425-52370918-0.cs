        XmlReader reader = XmlReader.Create(xmlpath, settings);
        XmlDocument doc = new XmlDocument();
        doc.Load(reader);
       if (GlobalNode.SelectSingleNode("MinTimeMs") == null)
        {
            XmlNode newNode = doc.CreateNode(XmlNodeType.Element, "MinTimeMs", "");
            newNode.InnerText = "0";
            GlobalNode.AppendChild(newNode);    
            RequirementMinTime = GlobalNode.SelectSingleNode("MinTimeMs");
        }
        else
        {
            RequirementMinTime = GlobalNode.SelectSingleNode("MinTimeMs");
        }
