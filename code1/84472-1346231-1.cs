    Directory.SetCurrentDirectory(@"C:\23055329\files\desktop wallpaper");
    List<FileInfo> files = new List<FileInfo>();
    List<string> fileTypes = new List<string>()
    {
        "*.jpg",
        "*.jpeg",
        "*.gif",
        "*.bmp",
        "*.png",
        "*.tif",
        "*.tiff"
    };
    
    DirectoryInfo dir = new DirectoryInfo(Directory.GetCurrentDirectory());
    foreach (string fileType in fileTypes)
    {
        files.AddRange(dir.GetFiles(fileType));
    }
    
    files.Sort(new Comparison<FileInfo>(delegate(FileInfo x, FileInfo y)
    {
        return x.LastWriteTime.CompareTo(y.LastWriteTime);
    }));
    
    foreach (FileInfo file in files)
    {
        // do something with the FileInfo
        Console.WriteLine(file.ToString());
    }
