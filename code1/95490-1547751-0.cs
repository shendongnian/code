    static IEnumerable<FileSystemInfo> GetAllFilesAndDirectories(string path)
    {
        string currentDirectory = "";
        string[] files = Directory.GetFiles( // skip empty subfolders
            path, "*.*", SearchOption.AllDirectories);
        foreach (string file in files)
        {
            if(currentDirectory != Path.GetDirectoryName(file))
            {
                // First time in this directory: return it
                currentDirectory = Path.GetDirectoryName(file);
                yield return new DirectoryInfo(currentDirectory);
            }
            yield return new FileInfo(file);
        }
    }
    static void Main(string[] args)
    {
        foreach (FileSystemInfo info in GetAllFilesAndDirectories(@"c:\intel"))
        {
            Console.WriteLine("{0} ({1})", info.FullName, info.Attributes);
        }
    }
