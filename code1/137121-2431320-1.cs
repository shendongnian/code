    public void SomeFunction()
    {
        Lists lists = new Lists(); //http://server/_vti_bin/Lists.asmx
        XmlNode coll = lists.GetListCollection();
        XmlNamespaceManager nsMgr = new XmlNamespaceManager(coll.OwnerDocument.NameTable);
        nsMgr.AddNamespace("sp", "http://schemas.microsoft.com/sharepoint/soap/");
        nsMgr.AddNamespace("z", "#RowsetSchema");
        XmlDocument xmlDoc = new XmlDocument();
        XmlElement query = xmlDoc.CreateElement("Query");
        XmlElement viewFields = xmlDoc.CreateElement("ViewFields");
        XmlElement queryOptions = xmlDoc.CreateElement("QueryOptions");
        viewFields.InnerXml = "<FieldRef Name=\"Modified_x0020_By\" />";
        queryOptions.InnerXml = "<ViewAttributes Scope=\"RecursiveAll\"/>";
        XmlNodeList siteLists = coll.SelectNodes("//sp:List", nsMgr);
        foreach (XmlNode list in siteLists)
        {
            if (list.Attributes["ServerTemplate"].Value != "101") continue; //101=DocLib
            XmlNode listItemCollection = lists.GetListItems(list.Attributes["Name"].Value, string.Empty, query,
                                                            viewFields, "4000",
                                                            queryOptions, null);
            XmlNodeList listItems = listItemCollection.SelectNodes("//z:row", nsMgr);
            foreach (XmlNode listItem in listItems)
            {
                if (listItem.Attributes["ows_FSObjType"] == null) continue;
                if (!listItem.Attributes["ows_FSObjType"].Value.EndsWith("#1")) continue;
                PrintModifiedBy(listItem);
            }
        }
    }
    private void PrintModifiedBy(XmlNode listItem)
    {
        string modifiedBy;
        if (listItem.Attributes["Modified_x0020_By"] != null)
            modifiedBy = listItem.Attributes["ows_Modified_x0020_By"].Value;
        else
            modifiedBy = listItem.Attributes["ows_Editor"].Value;
        Console.WriteLine(modifiedBy);
    }
