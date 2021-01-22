    private bool itemDoesntExist()
    {
        XmlDocument doc = new XmlDocument();
        doc.LoadXml("<Document><Query><Where><Contains><FieldRef Name=\"ID\" /><Value Type=\"Text\">" + this.ID  + "</Value></Contains></Where></Query><ViewFields /><QueryOptions /></Document>");
        XmlNode listQuery = doc.SelectSingleNode("//Query");
        XmlNode listViewFields = doc.SelectSingleNode("//ViewFields");
        XmlNode listQueryOptions = doc.SelectSingleNode("//QueryOptions");
        XmlNode items = this.wsLists.GetListItems(this.ListName , string.Empty, listQuery, listViewFields, string.Empty, listQueryOptions, null);
        if (items.ChildNodes[1].Attributes["ItemCount"].Value == "0")
        {
            return true; 
        }
        else
        {
            return false; 
        }
    }
