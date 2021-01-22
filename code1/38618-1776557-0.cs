    public static void ForceDeleteDirectory(string path)
    {
        DirectoryInfo root;
        Stack<DirectoryInfo> fols;
        DirectoryInfo fol;
        fols = new Stack<DirectoryInfo>();
        root = new DirectoryInfo(path);
        fols.Push(root);
        while (fols.Count > 0)
        {
            fol = fols.Pop();
            fol.Attributes = fol.Attributes & ~(FileAttributes.Archive | FileAttributes.ReadOnly | FileAttributes.Hidden);
            foreach (DirectoryInfo d in fol.GetDirectories())
            {
                fols.Push(d);
            }
            foreach (FileInfo f in fol.GetFiles())
            {
                f.Attributes = f.Attributes & ~(FileAttributes.Archive | FileAttributes.ReadOnly | FileAttributes.Hidden);
                f.Delete();
            }
        }
        root.Delete(true);
    }
