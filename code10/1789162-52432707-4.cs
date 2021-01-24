    static void Main(string[] args)
    {
        StringBuilder sb = new StringBuilder();
        Console.WriteLine("Write a line ending in '#'.");
        ConsoleKeyInfo keyInfo;
        do
        {
            keyInfo = Console.ReadKey();
            // Evaluate Input Key
            if (int.TryParse(keyInfo.Key.ToString(), out int i))
            {
                ; // do something with an int
            }
            else
            {
                ; // do something with char 
            }
            if (keyInfo.KeyChar != '#') 
            {
                sb.Append(keyInfo.KeyChar);
            }
        }
        while (keyInfo.KeyChar != '#');
        Console.WriteLine();
        Console.WriteLine($"You typed '{sb.ToString()}' which is {sb.Length.ToString()} character(s).");
        Console.WriteLine("Press any key to exit.");
        Console.ReadLine();
    }
