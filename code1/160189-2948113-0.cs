    static void Main(string[] args)
    {
        var files = Directory.GetFiles(@"d:\", "*").OrderByDescending(d => new FileInfo(d).LastWriteTime);
        foreach(var directory in files)
        {
            Console.WriteLine(directory);
        }
    
        Console.ReadLine();
    }
