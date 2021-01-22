    using System.IO;
    using System.IO.Compression;
    private static void CreateZipFile(IEnumerable<FileInfo> files, string archiveName)
    {
        using (var stream = File.OpenWrite(archiveName))
        {
            using (ZipArchive archive = new ZipArchive(stream, System.IO.Compression.ZipArchiveMode.Create))
            {
                 foreach (var item in files)
                 {
                     archive.CreateEntryFromFile(item.FullName, item.Name, CompressionLevel.Optimal);                       
                 }
             }
        }
    }
