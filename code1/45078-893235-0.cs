    Outlook.Folders olFolders = OutlookApp.Session.Folders;
    
    for (int i = 1; i <= olFolders.Count; i++)
    {
       if (olFolders[i].EntryID == olExplorer.CurrentFolder.EntryID)
       {
          // folder found assign and use it.
       }
    }
