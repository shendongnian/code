    public void useMyArchiveStream(Action<Stream> doStuff)
    {
        using (var archive = ZipFile.OpenRead(_filepath))
        {
            var entry = archive.GetEntry("test.path");
            using (var myStream = entry.Open())
            {
                doStuff(myStream);
            }
        }
    }
