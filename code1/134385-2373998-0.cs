    public string[] GetFileExtensions(string path)
    {
        System.IO.DirectoryInfo directory = 
            new System.IO.DirectoryInfo(System.IO.Path.GetDirectoryName(path));
       
        return directory.GetFiles(
            System.IO.Path.GetFileNameWithoutExtension(path) + ".*")
            .Select(f => f.Extension).ToArray();
    }
