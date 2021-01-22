    foreach(System.IO.FileSystemInfo fsi in 
        new System.IO.DirectoryInfo(path).GetFileSystemInfos())
    {
        if (fsi is System.IO.DirectoryInfo)
            ((System.IO.DirectoryInfo)fsi).Delete(true);
        else
            fsi.Delete();
    }
