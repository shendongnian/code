    public struct Flder
    {
        public String name;
        public MAPIFolder folder;
    }
...
    private static void WalkTree(Folders topfolder, String path)
    {
        if (topfolder.Count > 0)
        {
            foreach (MAPIFolder f in topfolder.AsParallel())
            {
                if (!f.Name.Contains("Public"))
                {
                    Flder fld = new Flder();
                    fld.name = path + "\\" + f.Name;
                    fld.folder = f;
                    folderList.Add(fld);
                    try
                    {
                        WalkTree(f.Folders, path + "\\" + f.Name);
                    }
                    catch
                    {
                        continue; // skip any errors
                    }
                }
            }
        }
    }
