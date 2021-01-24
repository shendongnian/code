     ClientContext context = new ClientContext(@"http://sp2016/sites/test");
        Microsoft.SharePoint.Client.File file = context.Web.GetFileByServerRelativeUrl(@"/sites/test/Documents1/folder2/test.txt");
        ListItem lstitem = file.ListItemAllFields;
        context.Load(lstitem);
        context.ExecuteQuery();
        lstitem["Title"] = "Mercedes";
        lstitem.Update();
        context.ExecuteQuery();
