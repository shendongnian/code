    private List<string> GetAllEmpIDs(string xml)
    {
        XmlDocument doc = new XmlDocument();
        doc.LoadXml(xml);
        List<string> lstEmpID = new List<string>();
        foreach(XmlNode node in doc.DocumentElement.ChildNodes)
        {
            lstEmpID.Add(node.Attributes[@"href"].Value.ToString().Split(new char[]{'='})[1]);
        }
        return lstEmpID;
    }
