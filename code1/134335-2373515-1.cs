    private static void ReadFromFile()
    {
        long offset = 0;
    
        FileSystemWatcher fsw = new FileSystemWatcher
        {
            Path = Environment.CurrentDirectory,
            Filter = "test.txt"
        };
    
        FileStream file = File.Open(
            "test.txt",
            FileMode.Open,
            FileAccess.Read,
            FileShare.Write);
    
        StreamReader reader = new StreamReader(file);
        while (true)
        {
            fsw.WaitForChanged(WatcherChangeTypes.Changed);
            
            file.Seek(offset, SeekOrigin.Begin);
            if (!reader.EndOfStream)
            {
                do
                {
                    Console.WriteLine(reader.ReadLine());
                } while (!reader.EndOfStream);
    
                offset = file.Position;
            }
        }
    }
