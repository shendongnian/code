    static void WriteDirectories(string path, int indent = 0)
    {
        Console.WriteLine(new string(' ', indent * 2) + Path.GetFileName(path));
        foreach (string subDir in Directory.GetDirectories(path))
        {
            WriteDirectories(subDir, indent + 1);
        }
    }
