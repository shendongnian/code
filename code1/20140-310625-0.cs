    /// <summary>
    /// Returns whether the given path/file is a link
    /// </summary>
    /// <param name="shortcutFilename"></param>
    /// <returns></returns>
    public static bool IsLink(string shortcutFilename)
    {
        string pathOnly = System.IO.Path.GetDirectoryName(shortcutFilename);
        string filenameOnly = System.IO.Path.GetFileName(shortcutFilename);
    
        Shell32.Shell shell = new Shell32.ShellClass();
        Shell32.Folder folder = shell.NameSpace(pathOnly);
        Shell32.FolderItem folderItem = folder.ParseName(filenameOnly);
        if (folderItem != null)
        {
            return folderItem.IsLink;
        }
        return false; // not found
    }
    
    
