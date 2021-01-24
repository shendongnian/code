    Uri filename = new Uri("Your file Url");
    string server = filename.AbsoluteUri.Replace(filename.AbsolutePath, "");
    string serverrelative = filename.AbsolutePath;
    Microsoft.SharePoint.Client.File file= web.GetFileByServerRelativeUrl(serverrelative);
    ListItem lstItem = file.ListItemAllFields;
    clientContext.Load(lstItem);
    clientContext.ExecuteQuery();
    Once you have got the list handle, you can update the editor field as below
    
    lstItem[<Field Name Here>] =  <value here>
    lstItem.Update();
    clientContext.ExecuteQuery();
