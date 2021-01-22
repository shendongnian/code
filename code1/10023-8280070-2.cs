    string[] ext = new string[2] { "*.CAB", "*.MSU" };
    foreach (string found in ext)
    {
        string[] extracted = Directory.GetFiles("C:\\test", found, System.IO.SearchOption.AllDirectories);
        foreach (string file in extracted)
        {
            Console.WriteLine(file);
        }
    }
