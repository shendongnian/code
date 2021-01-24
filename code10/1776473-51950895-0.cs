    static void Main(string[] args)
    {
        // this gets all matching files in a string array...
        string[] allfiles = Directory.GetFiles(@"C:\MotherDir\", "FileINeed.txt", SearchOption.AllDirectories);
        
        // parse the string array and call ProcessFiles for each one...
        foreach (var file in allfiles)
        {
            ProcessFiles(file);
        }
        Console.WriteLine("Finished.");
        Console.ReadKey(); //Gets pause at the end of the program
    }
