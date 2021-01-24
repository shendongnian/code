    File file = ClientContext.Web.GetFileByServerRelativeUrl(docUrl);
    ClientContext.Load(file, f => f.ListItemAllFields);
    ClientContext.ExecuteQuery();             
    ListItem item = file.ListItemAllFields;
    string fileName = item.FieldValues["FileLeafRef"].ToString();
    string fileType = System.IO.Path.GetExtension(FileName);
    var furl = item.FieldValues["_dlc_DocIdUrl"] as FieldUrlValue;
    string documentPermalinkUrl = furl.Url;
    Guid uniqueId = new Guid(item.FieldValues["UniqueId"].ToString());
                
