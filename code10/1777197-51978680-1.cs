    public static XmlNode SelectXmlNode()
        {
            XmlNode addNode=null;
            string xmlString = "*xmlString*"
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlString);
            var node = doc.ChildNodes;
            var siblings = node[0].NextSibling.ChildNodes;
            foreach (XmlNode cnode in siblings)
            {
                    var childnode = cnode.ChildNodes[0].NextSibling.ChildNodes[0].ChildNodes[0].FirstChild;
                    if (childnode.Name == "addressbook")
                    {
                        addNode = cnode.ChildNodes[0];
                    }  
                
            }
            return addNode;
        }
