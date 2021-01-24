            XmlDocument doc = new XmlDocument();
            doc.LoadXml("yourxmlhere");
            Configuration configuration = new Configuration();
            XmlNode root = doc.FirstChild;
            if (root.HasChildNodes)
            {
                foreach (XmlNode item in root.ChildNodes)
                {
                    configuration = SetValueByPropertyName(configuration, item.Attributes["name"].Value, item.FirstChild.InnerText);
                }
            }
        
