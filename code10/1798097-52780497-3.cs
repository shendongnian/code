    public List<Folder> GetSubFolders(Folder f)
    {
        List<Folder> folders = new List<Folder>();
        if(f.Folders.Count > 0)
        {
            foreach(Folder ff in f.Folders)
            {
                if(ff.DefaultMessageClass.Contains("IPM.Post")
                    folders.Add(ff);
                folders.AddRange(GetSubFolders(ff));
                Marshal.ReleasComObject(ff);
            }
        }
        return folders;
    }
