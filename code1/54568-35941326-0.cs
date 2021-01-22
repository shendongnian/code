    XmlDocument doc = new XmlDocument();
            doc.Load(configPath);
            XmlNodeList list = doc.DocumentElement.GetElementsByTagName("Book");
            if (list.Count != 0)
            {
                for (int i = 0; i < list[0].ChildNodes.Count; i++)
                {
                    XmlNode child = list[0].ChildNodes[i];
                }
            }
