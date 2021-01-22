    // Adds attachments from a list item in one SharePoint server to a list item in another SharePoint server.
    //   addResults is the return value from a lists.UpdateListItems call.
    private void AddAttachments(XElement addResults, XElement listItem)
    {
        XElement itemElements = _listsService2003.GetAttachmentCollection(_listNameGuid, GetListItemIDString(listItem)).GetXElement();
        XNamespace s = "http://schemas.microsoft.com/sharepoint/soap/";
        var items = from i in itemElements.Elements(s + "Attachment")
                    select new { File = i.Value };
        WebClient Client = new WebClient();
        Client.Credentials = new NetworkCredential("user", "password", "domain");
        // Pull each attachment file from old site list and upload it to the new site list.
        foreach (var item in items)
        {
            byte[] data = Client.DownloadData(item.File);
            string fileName = Path.GetFileName(item.File);
            string id = GetID(addResults);
            _listsService2007.AddAttachment(_newListNameGuid, id, fileName, data);
        }
    }
