    public static IEnumerable<ListItem> GetSharepointFiles2(string sharePointsite, string libraryName, string username, string password, string subFolders)
    {
        Uri filename = new Uri(sharePointsite);
        List<ListItem> items = new List<ListItem>();
        using (ClientContext cxt = new ClientContext(filename))
        {
            cxt.Credentials = GetCreds(username, password);
            Web web = cxt.Web;
            cxt.Load(web, wb => wb.ServerRelativeUrl);
            cxt.ExecuteQuery();
            List list = web.Lists.GetByTitle(libraryName);
            cxt.Load(list);
            cxt.ExecuteQuery();
            CamlQuery camlQuery = new CamlQuery();
            camlQuery.ViewXml = "<View Scope='Recursive'><RowLimit>5000</RowLimit></View>";
            do
            {
                ListItemCollection listItems = list.GetItems(camlQuery);
                cxt.Load(listItems);
                cxt.ExecuteQuery();
                items.AddRange(listItems);
                camlQuery.ListItemCollectionPosition = listItems.ListItemCollectionPosition;
            } while (camlQuery.ListItemCollectionPosition != null);
            var filteritems = items.Where(tt => tt.FieldValues["FileRef"].ToString().StartsWith(web.ServerRelativeUrl + subFolders));
            return filteritems;
        }
    }
