    XmlDocument xmldoc = new XmlDocument();
    XmlNodeList xmlnode;
    int i = 0;
    string str = null;
    FileStream fs = new FileStream(@"Books.xml", FileMode.Open, FileAccess.Read);
    xmldoc.Load(fs);
    xmlnode = xmldoc.GetElementsByTagName("Book");
    
    for (i = 0; i <= xmlnode.Count - 1; i++)
    {
        for (int j = 0; j <= xmlnode[i].ChildNodes.Count-1; j++)
        {
            if (xmlnode[i].ChildNodes.Item(j).Name == "Name")
                continue;
            xmlnode[i].ChildNodes.Item(j).InnerText.Trim();
            str = xmlnode[i].ChildNodes.Item(j).InnerText.Trim();
            MessageBox.Show(str);
        }
    }
