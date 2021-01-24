    public void useMyArchiveStream(String zipPath, String entryName, Action<Stream, String> doStuff)
    {
        using (var archive = ZipFile.OpenRead(zipPath))
        {
            var entry = archive.GetEntry(entryName);
            using (var myStream = entry.Open())
            {
                doStuff(myStream, entry.FullName);
            }
        }
    }
