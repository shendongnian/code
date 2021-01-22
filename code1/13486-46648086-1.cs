    var folder = new Shell().NameSpace(folderPath);
    foreach (FolderItem2 item in folder.Items())
    {
        var company = item.ExtendedProperty("Company");
        var author = item.ExtendedProperty("Author");
        // Etc.
    }
