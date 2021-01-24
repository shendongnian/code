    public T UseMyArchiveStream<T>(String zipPath, String entryName, Func<Stream, String, T> doStuff)
    {
        using (var archive = ZipFile.OpenRead(zipPath))
        {
            var entry = archive.GetEntry(entryName);
            using (var myStream = entry.Open())
            {
                return doStuff(myStream, entry.FullName);
            }
        }
    }
