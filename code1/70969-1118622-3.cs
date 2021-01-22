    using static UserExtension;
    long totalSize = 0L;
    var startFolder = new DirectoryInfo("<path to folder>");
    // iteration
    foreach(FileInfo file in startFolder.Walk())
    {
        totalSize += file.Length;
    }
    // linq
    totalSize = di.Walk().Sum(s => s.Length);
