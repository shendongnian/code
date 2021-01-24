    static void WriteTextToFile()
    {
        WriteTextToFile();
    }
    static void WriteTextToFile()
    {
        Console.WriteLine("Please enter some value:");
        var valueToWrite = Console.ReadLine();
        File.WriteAllText("Assignment4.txt", valueToWrite);
        Console.WriteLine("Thanks alot. Press a key to close.");
        Console.ReadKey();
    }
