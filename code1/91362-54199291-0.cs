    public string XmlEscape(string unescaped)
            {
                XmlDocument doc = new XmlDocument();
                var node = doc.CreateElement("root");
                node.InnerText = unescaped;
                return node.InnerXml;
            }
