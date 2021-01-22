    ... TraverseFolder(rootFolderID, userContext)
    {
        var folderById = new ...;
        TraverseFolder(folderById, rootFolderID, userContext);
        
        return folderById;
    }
    
    void TraverseFolder(folderById, folderID, userContext)
    {
        var folders = FolderService.Instance.GetSubFolders(userContext, folderID);
        foreach(var folder in folders)
        {
            folderById.Add(folder.FolderID, folder);
            TraverseFolder(folder.FolderID);
        }
    }
