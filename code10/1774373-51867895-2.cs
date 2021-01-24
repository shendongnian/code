    static void Main(string[] args)
    {
        List<FileItem> OldFile = new List<FileItem>
        {
            new FileItem() { FileID = 1, SysCount = 100, SysName = "One" },
            new FileItem() { FileID = 2, SysCount = 200, SysName = "Two" },
            new FileItem() { FileID = 3, SysCount = 300, SysName = "Three" },
            new FileItem() { FileID = 4, SysCount = 400, SysName = "Four" },
            new FileItem() { FileID = 5, SysCount = 500, SysName = "Five" }
        };
        List<FileItem> NewFile = new List<FileItem>
        {
            new FileItem() { FileID = 1, SysCount = 100, SysName = "One" },
            new FileItem() { FileID = 200, SysCount = 200, SysName = "Two" },
            new FileItem() { FileID = 3, SysCount = 300, SysName = "Three" },
            new FileItem() { FileID = 400, SysCount = 400, SysName = "Four" },
            new FileItem() { FileID = 5, SysCount = 500, SysName = "Five" }
        };
        var onlyInNew = NewFile.Except(OldFile, new FileComparer());
        var onlyInOld = OldFile.Except(NewFile, new FileComparer());
        var commonToBoth = OldFile.Intersect(NewFile, new FileComparer());
        Console.ReadLine();
    }
