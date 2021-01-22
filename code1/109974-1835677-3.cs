    static void Main(string[] args)
    {
        DirectoryInfo src = new DirectoryInfo(@"C:\temp");
        DirectoryInfo dst = new DirectoryInfo(@"C:\temp3");
    
        /*
         * My example NCR.txt
         *     *.txt
         *     a.lbl
         */
        CopyFiles(src, dst, true);
    }
    
    static void CopyFiles(DirectoryInfo source, DirectoryInfo destination, bool overwrite)
    {
        List<FileInfo> files = new List<FileInfo>();
    
        string[] fileNames = File.ReadAllLines("C:\\NCR.txt");
    
        foreach (string f in fileNames)
        {
            files.AddRange(source.GetFiles(f));
        }
    
        if (!destination.Exists)
            destination.Create();
    
        foreach (FileInfo file in files)
        {
            file.CopyTo(destination.FullName + @"\" + file.Name, overwrite);
        }
    }
