    public XmlDocument GetEntityXml<T>()
            {
                XmlDocument xmlDoc = new XmlDocument();
                XPathNavigator nav = xmlDoc.CreateNavigator();
                using (XmlWriter writer = nav.AppendChild())
                {
                    XmlSerializer ser = new XmlSerializer(typeof(List<T>), new XmlRootAttribute("TheRootElementName"));
                    ser.Serialize(writer, parameters);
                }
                return xmlDoc;
            }
