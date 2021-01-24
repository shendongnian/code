    XmlNodeList elemList = xml_doc.GetElementsByTagName("post");
    for (int i=0;i<elemList.Count; i ++)
    {
        string getValue = elemList[i].Attributes[postid].ChildNodes[1].InnerText;
        System.Diagnostics.Debug.WriteLine(getValue);
    }
