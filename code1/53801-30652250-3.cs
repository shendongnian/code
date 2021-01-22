    using (ZipArchive archive = ZipFile.OpenRead(pathToZip))
    {
        foreach (ZipArchiveEntry entry in archive.Entries)
        {
            entry.ExtractToFile(Path.Combine(destination, entry.FullName));
        }
    } 
