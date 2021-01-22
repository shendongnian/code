    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"E:\3\{90120000-0021-0000-0000-0000000FF1CE}-C1");
    if (dir.Exists)
    {
        setAttributesNormal(dir);
        dir.Delete(true);
    }
    . . .
    function setAttributesNormal(DirectoryInfo dir) {
        foreach (var subDir in dir.GetDirectories())
            setAttributesNormal(subDir);
        foreach (var file in dir.GetFiles())
        {
            file.Attributes = FileAttributes.Normal;
        }
    }
