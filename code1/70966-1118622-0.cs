    public static IEnumerable<FileInfo> Walk(this DirectoryInfo directory)
    {
        foreach(FileInfo file in directory.GetFiles())
        {
            yield return file;
        }
    
        foreach(DirectoryInfo subDirectory in directory.GetDirectories()
        { 
            foreach(FileInfo file in subDirectory.Walk())
            {
                yield return file;
            }
        }
    }
