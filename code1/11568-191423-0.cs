    foreach (string fileName in System.IO.Directory.GetFiles(path))
    {
        System.IO.FileInfo fileInfo = new System.IO.FileInfo(fileName);
        fileInfo.Attributes |= System.IO.FileAttributes.ReadOnly;
        // or
        fileInfo.IsReadOnly = true;
    }
