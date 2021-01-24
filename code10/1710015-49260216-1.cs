    public static void Replace(string path, string from, string to)
    {
        string[] folders = System.IO.Directory.GetDirectories(path, "*", System.IO.SearchOption.TopDirectoryOnly);
        foreach (string folder in folders)
        {
            // recursively rename all subfolders first
            Replace(folder, from, to);
            string prefix = path;
            string newFolderName = prefix + folder.Substring(prefix.Length).Replace(from, to);
            
            if (newFolderName != folder_
                System.IO.Directory.Move(folder, newFolderName);
        }
    }
