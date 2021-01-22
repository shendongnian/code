    static void Main(string args[])
    {
        using (FileStream f = File.Open("c:\\software\\code.txt", FileMode.Open, FileAccess.Read, FileShare.None))
        {
            Console.Write("File is open. Press Enter when done.");
            Console.ReadLine();
        }
    }
