    public IEnumerable<FileInfo> FindFile(string fileName)
    {
        if (String.IsNullOrEmpty(fileName))
            throw new ArgumentException("fileName");
        foreach (var drive in Directory.GetLogicalDrives())
        {
            using (var e = FindFile(fileName, drive).GetEnumerator())
                while (e.MoveNext())
                    yield return e.Current;
        }
    }
    public IEnumerable<FileInfo> FindFile(string fileName, string folderName)
    {
        if(String.IsNullOrEmpty(fileName))
            throw new ArgumentException("fileName");
        if(String.IsNullOrEmpty(fileName))
            throw new ArgumentException("folderName");
        var matchingFiles = Directory.GetFiles(folderName)
                                     .Where(file => Path.GetFileName(file) == fileName)
                                     .Select(file => new FileInfo(file));
        using (var e = matchingFiles.GetEnumerator())
            while (e.MoveNext())
                yield return e.Current;
        foreach (var directory in Directory.GetDirectories(folderName))
        {
            using (var e = FindFile(fileName, directory).GetEnumerator())
                while (e.MoveNext())
                    yield return e.Current;
        }
    }
