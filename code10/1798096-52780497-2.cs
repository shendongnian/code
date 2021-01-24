    Microsoft.Office.Interop.Outlook.Application app = new Microsoft.Office.Interop.Outlook.Application();
    List<Folder> folders = new List<Folder>();
    foreach(Folder f in app.Session.Folders)
    {
        if(ff.DefaultMessageClass.Contains("IPM.Post")
            folders.Add(f);
        folders.AddRange(GetSubFolders(f));
        // Dont forget to release the object cause Outlook don't like too many open obejcts
        Marshal.ReleaseComObject(f);
    }
