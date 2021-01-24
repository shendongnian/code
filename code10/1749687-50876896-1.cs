    while (true)
    {
        if (Directory.Exists(CACHE_PATH))
        {
            var filesList = new DirectoryInfo(CACHE_PATH).GetFiles("*", SearchOption.AllDirectories);
            long directorySize = filesList.Sum(e => e.Length);
    
            if (directorySize > CACHE_MAX_SIZE)
            {
                filesList.OrderBy(z => z, new FileInfoAccessTimeComparer()).TakeWhile(z => directorySize > CACHE_MAX_SIZE * 0.75)
                    .ForEach(z =>
                    {
                        z.Delete();
                        directorySize -= z.Length;
                    });
            }
            filesList = null;
        }
        Thread.Sleep(CACHE_CLEANUP_INTERVAL);
    }
