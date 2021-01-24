    var extensoes = new List<string>() { ".jpg", ".bmp", ".png", ".tiff", ".gif" };
    //  set up list of root folders
    foreach (var folderNumber in Enumerable.Range(1000, 11).ToList())
    {
        var folderToSearch = $@"\\share\folder{folderNumber}";
        List<string> fileList = Directory.EnumerateFiles(
                                       folderToSearch, "*.*",
                                       SearchOption.AllDirectories)
                                          .Select(x => Path.GetFileName(x))
                                          .Where(x => extensoes.Contains(Path.GetExtension(x)))
                                          .ToList();
        Console.WriteLine(fileList.Count());
        foreach (var fileName in fileList)
        {
            Console.WriteLine(fileName);
        }
    }
