    List doclib = ctx.Web.Lists.GetByTitle("Reporting Rosters"); 
    ctx.Load(doclib);
    ctx.ExecuteQuery();
    
    Microsoft.SharePoint.Client.CamlQuery camlQuery = CamlQuery.CreateAllItemsQuery();
    ListItemCollection listItems = doclib.GetItems(camlQuery);
    clientContext.Load(listItems);
    clientContext.ExecuteQuery();
    
    foreach (var listItem in listItems)
    {
    	Console.WriteLine(listItem["FileLeafRef"].ToString());  // gives the file name
    	Console.WriteLine(listItem["FileRef"].ToString());  // gives the file's server relative URL
    }
