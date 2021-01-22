    string[] filePaths = Directory.GetFiles(@"c:\dir");
    for (int i = 0; i < filePaths.Length; ++i) {
        string path = filePaths[i];
        Console.WriteLine(System.IO.Path.GetFileName(path));
    }
             
