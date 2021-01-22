    var items = listSvc.GetListItems(listname, null, null, null, null, null);
    
    var pager = items.ChildNodes[1].Attributes["ListItemCollectionPositionNext"] != null ? items.ChildNodes[1].Attributes["ListItemCollectionPositionNext"].Value : string.Empty;
    var pagerXml = new XmlDocument();
    pagerXml.InnerXml = "<QueryOptions><Paging ListItemCollectionPositionNext=\"\" /></QueryOptions>";
    var pagerNode = pagerXml.GetElementsByTagName("QueryOptions")[0];
    
    while (!string.IsNullOrEmpty(pager))
    {
        pagerNode.ChildNodes[0].Attributes[0].Value = pager;
        var temp = listSvc.GetListItems(listname, null, null, null, null, pagerNode);
        foreach (XmlNode c in temp.ChildNodes[1].ChildNodes)
        {
            var c2 = items.OwnerDocument.ImportNode(c, true);
            items.ChildNodes[1].AppendChild(c2);
        }
    
        pager = temp.ChildNodes[1].Attributes["ListItemCollectionPositionNext"] != null ? temp.ChildNodes[1].Attributes["ListItemCollectionPositionNext"].Value : string.Empty;
    }
