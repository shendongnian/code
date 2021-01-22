    public void Recurse(DirectoryInfo directory)
    {
        foreach (FileInfo fi in directory.GetFiles())
        {
            fi.IsReadOnly = false; // or true
        }
        foreach (DirectoryInfo subdir in directory.GetDirectories())
        {
            Recurse(subdir);
        }
    }
