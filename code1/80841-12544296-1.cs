    static void Main(string[] args)
    {
        DirectoryInfo di = new DirectoryInfo(@"c:\aaa");
        CleanDirectory(di);
    }
    private static void CleanDirectory(DirectoryInfo di)
    {
        if (di == null)
            return;
        foreach (FileSystemInfo fsEntry in di.GetFileSystemInfos())
        {
            CleanDirectory(fsEntry as DirectoryInfo);
            fsEntry.Delete();
        }
        WaitForDirectoryToBecomeEmpty(di);
    }
    private static void WaitForDirectoryToBecomeEmpty(DirectoryInfo di)
    {
        for (int i = 0; i < 5; i++)
        {
            if (di.GetFileSystemInfos().Length == 0)
                return;
            Console.WriteLine(di.FullName + i);
            Thread.Sleep(50 * i);
        }
    }
