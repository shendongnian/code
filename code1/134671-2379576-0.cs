    public void SaveForm(string formXml, string fileName, string url, Dictionary<string, string> extraColumns)
    {
        SPWeb web = SPContext.Current.Web;
        string webUrl = web.Url;
        if (!webUrl.EndsWith("/"))
            webUrl += "/";
    
        string relativeUrl = url.Replace(webUrl, string.Empty);
        string listName = relativeUrl.Substring(0, relativeUrl.IndexOf('/'));
        SPList destinationList = web.Lists[listName];
        SPFolder destinationFolder = destinationList.RootFolder;
    
        string lowerCaseFilename = fileName.ToLower();
        if (!lowerCaseFilename.EndsWith(".xml"))
            fileName += ".xml";
    
        web.AllowUnsafeUpdates = true;
        SPFile file = destinationFolder.Files.Add(fileName, Encoding.UTF8.GetBytes(formXml));
    
        if ((extraColumns != null) && (extraColumns.Count > 0))
        {
            foreach (KeyValuePair<string, string> column in extraColumns)
            {
                file.Item[column.Key] = column.Value;
            }
            file.Item.Update();
        }
    
        web.AllowUnsafeUpdates = false;
    }
