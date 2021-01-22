    foreach (XmlNode node in nodes)
    {
        string Title1 = node["OC_Ttl1"].InnerText;
        string Title2 = node["OC_Ttl2"].InnerText;
        string OrgName = node["OC_OL31"].InnerText;
         Console.WriteLine(Title1 + "/" + Title1 + "/" + OrgName);
    }
