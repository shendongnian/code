    public static class FileExtensions
    {
        public static IEnumerable<FileSystemInfo> AllFilesAndFolders(this DirectoryInfo dir)
        {
            foreach (var f in dir.GetFiles())
                yield return f;
            foreach (var d in dir.GetDirectories())
            {
                yield return d;
                foreach (var o in AllFilesAndFolders(d))
                    yield return o;
            }
        }
    }
    void Test()
    {
        DirectoryInfo from = new DirectoryInfo(@"C:\Test");
        using (FileStream zipToOpen = new FileStream(@"Test.zip", FileMode.Create))
        {
            using (ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Create))
            {
                foreach (FileInfo file in from.AllFilesAndFolders().Where(o => o is FileInfo).Cast<FileInfo>())
                {
                    var relPath = file.FullName.Substring(from.FullName.Length+1);
                    ZipArchiveEntry readmeEntry = archive.CreateEntryFromFile(file.FullName, relPath);
                }
            }
        }
    }
