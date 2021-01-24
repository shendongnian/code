    public void UseMyArchiveStream()
    {
        using(var archive = ZipFile.OpenRead(_filepath))
        {
            var entry = archive.GetEntry("test.path");
            using(var myStream = entry.Open())
            {
                //Do stuff
            }
        }
    }
