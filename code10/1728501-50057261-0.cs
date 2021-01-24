    public void ZipTesting()
    {
        string zipPath = @"c:\zipTest\TestArchive.zip";
        using (ZipArchive archive = ZipFile.OpenRead(zipPath))
        {
            foreach (ZipArchiveEntry entry in archive.Entries)
            {
                Console.WriteLine(entry.FullName);
            }
        }
    }
