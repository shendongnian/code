    void Start () {
        string data = xmlRawFile.text;
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(data);
        XmlNodeList nodes = xmlDoc.GetElementsByTagName("node");
        Debug.Log(nodes.Count);
        foreach (XmlNode node in nodes)
        {
            string aux=node.Attributes["id"].Value;           
            XmlNodeList childs = node.ChildNodes;
            Debug.Log(childs.Count);
            Debug.Log(aux);
            for(int i=0; i<childs.Count;i++)
            {
                if(childs[i].Attributes["key"].Value == "author.name")
                {
                    Debug.Log(childs[i].InnerText);
                }            
            }
        }
    }
