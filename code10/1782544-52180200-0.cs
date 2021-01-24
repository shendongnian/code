        ClientContext cxt = new ClientContext("SHAREPOINT ADDRESS");
        List doclib = cxt.Web.Lists.GetByTitle("Reporting Rosters");
        cxt.Load(doclib);
        cxt.Load(doclib.RootFolder);
        cxt.Load(doclib.RootFolder.Folders);
        cxt.Load(doclib.RootFolder.Files);
        cxt.ExecuteQuery();
        FolderCollection fol = doclib.RootFolder.Folders;
        List<string> listFile = new List<string>();
        foreach(Folder f in fol)
        {
            if (f.Name == "filename")
            {
                cxt.Load(f.Files);
                cxt.ExecuteQuery();
                FileCollection fileCol = f.Files;
                foreach (File file in fileCol)
                {
                    listFile.Add(file.Name);
                }
            }
        }
