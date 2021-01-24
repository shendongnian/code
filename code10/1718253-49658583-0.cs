    Using Shell32; // reference  browse to c:\Windows\System32\shell32.dll
    
    class x
    {
    public int Hwnd { get; private set; }
    public void ListAllFolderObjects()
    {
    
     Shell32.Shell shell = new Shell32.Shell();
     Folder folder = shell.BrowseForFolder((int)Hwnd, "Choose Folder", 0, 0);
     if (folder != null)
        GetFolderObjects(folder);
    }
    
    private void GetFolderObjects(Folder folder)
    {
     foreach (FolderItem currentItem in folder.Items())
     {
        // a
        string sType = currentItem.Type;
        string sName = currentItem.Name; 
    
        if (sType == "folder")
        {
            Folder f = (Folder)currentItem.GetFolder; //cast object
            GetFolderObjects(f); // recurse
     }
    }
    }
    
    // from main
    ListAllFolderObjects();
