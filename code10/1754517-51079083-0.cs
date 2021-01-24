    var latestTime = DateTime.Now - LogUtil.logPurgeTime;
    var pattern = "webMonlog*";
    var files = dir.EnumerateFiles(pattern)
                   .Where(x => x.CreationTime < latestTime)
                   .ToList();
    Console.WriteLine("Getting old Log Files...");
    foreach (var file in files)
    {
        file.Delete();
        Console.WriteLine(file.FullName);
    }
