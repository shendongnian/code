    private void SharePoint2010AddAttachment(ClientContext ctx, 
                                         string listName, string itemId, 
                                         string fileName, byte[] fileContent)
    {
        var listsSvc = new sp2010.Lists();
        listsSvc.Credentials = _sharePointCtx.Credentials;
        listsSvc.Url = _sharePointCtx.Web.Context.Url + "_vti_bin/Lists.asmx";
        listsSvc.AddAttachment(listName, itemId, fileName, fileContent);
    }
