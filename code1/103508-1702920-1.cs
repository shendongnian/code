    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"E:\3\{90120000-0021-0000-0000-0000000FF1CE}-C1");
    if (dir.Exists)
    {
        setAttributesNormal(dir);
        dir.Delete(true);
    }
    . . .
    function setAttributesNormal(DirectoryInfo dir) {
        foreach (string subDirPath in dir.GetDirectories())
            setAttributesNormal(new DirectoryInfo(subDirPath));
        foreach (string filePath in dir.GetFiles()) {
            var file = new FileInfo(filePath)
            file.Attributes = FileAttributes.Normal;
        }
    }
