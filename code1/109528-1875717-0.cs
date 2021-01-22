    VersionControlServer sourceControl; // actually instantiated...
             
    ItemSet items = sourceControl.GetItems(sourcePath, VersionSpec.Latest, RecursionType.Full);
    
    foreach (Item item in items.Items)
    {
        // build relative path
        string relativePath = BuildRelativePath(sourcePath, item.ServerItem);
    
        switch (item.ItemType)
        {
        case ItemType.Any:
            throw new ArgumentOutOfRangeException("ItemType returned was Any; expected File or Folder.");
        case ItemType.File:
            item.DownloadFile(Path.Combine(targetPath, relativePath));
            break;
        case ItemType.Folder:
            Directory.CreateDirectory(Path.Combine(targetPath, relativePath));
            break;
        }
    }
