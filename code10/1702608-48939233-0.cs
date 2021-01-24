    // Will be an IEnumerable<string> not an string[]
    var fileNames = Directory.GetFiles(filePath).Select(Path.GetFileName);
    Console.WriteLine("-----Files:-----");
    foreach (string files in fileNames)
    {
        Console.WriteLine(files);
    }
    Console.ReadLine();
