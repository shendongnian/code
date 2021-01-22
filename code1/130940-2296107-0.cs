    Dictionary<string, int> folderById = new Dictionary<string,int>();
    public void Start()
    {
        // code for initial context + folder id
        RecurseFolders(userContext, folderId);
    }
    
    public void RecurseFolders(string userContext, int folderId)
    {
        foreach (Folder.Folder folder in FolderService.Instance.GetSubFolders(userContext, folderID)) {
            folderById.Add(folder.FolderID, folder);
            RecurseFolders(userContext, folder.folderId);
        }
    }
