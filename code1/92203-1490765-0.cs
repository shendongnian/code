    XmlDocument xmlDoc = new XmlDocument();
    xmlDoc.Load("yourfilename.xml");
    
    XmlNodeList dataNodes = xmlDoc.SelectNodes("/information/data");
    
    foreach(XmlNode node in dataNodes)
    {
        int id = Convert.ToInt32(node.SelectSingleNode("id").InnerText);
        string name = node.SelectSingleNode("name").InnerText;
        int age = Convert.ToInt32(node.SelectSingleNode("age").InnerText);
    
        // insert into database, e.g. using SqlCommand or whatever
    }
