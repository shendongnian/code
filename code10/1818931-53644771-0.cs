    static void Main(string[] args)
    {
        Program program = new Program();
        string word = program.PickRandom();
        Console.WriteLine(word); 
        // keep the console open after the code has executed by waiting for a keypress
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey(); 
    }
