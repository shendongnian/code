    public FileInfo MakeUnique(string path)
    {            
        string dir = Path.GetDirectoryName(path);
        string fileName = Path.GetFileNameWithoutExtension(path);
        string fileExt = Path.GetExtension(path);
     
        for (int i = 1; ;++i) {
            if (!File.Exists(path))
                return new FileInfo(path);
            path = Path.Combine(dir, fileName + " " + i + fileExt);
        }
    }
