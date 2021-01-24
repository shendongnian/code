    public void useMyArchiveStream(String zipPath, String entryName, Action<Stream> doStuff)
    {
        using (var archive = ZipFile.OpenRead(zipPath))
        {
            var entry = archive.GetEntry(entryName);
            using (var myStream = entry.Open())
            {
                doStuff(myStream);
            }
        }
    }
