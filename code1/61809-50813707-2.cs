        SPList list = web.Lists[listname];
        
        SPQuery query = new SPQuery();
        query.Query = "<OrderBy><FieldRef Name='ID' /></OrderBy>";
        //Scope="Recursive" retrieves items from all folders and subfolders in a list
        query.ViewFields = "<FieldRef Name='" + Lists.MRPLibrary.RebateClaimed + "' /><FieldRef Name='ID'/>";
        query.ViewAttributes = "Scope=\"RecursiveAll\"";
        query.RowLimit = 100;
        
        do
        {
            SPListItemCollection items = list.GetItems(query);
        
            foreach (SPListItem listItem in items)
            {
                                         
            }
        
            query.ListItemCollectionPosition = items.ListItemCollectionPosition;
        
        } while (query.ListItemCollectionPosition != null);
        
    }
