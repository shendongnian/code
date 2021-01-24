    static Random rng = new Random();
    static void download(string filepath)
    {
        Console.WriteLine("Downloading " + filepath);
        Thread.Sleep(500 + rng.Next(1000)); // Simulate random downloading time.
        Console.WriteLine("Downloaded " + filepath);
    }
