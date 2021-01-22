    static void Main(string[] args)
    {
        Console.SetIn(new StreamReader(Console.OpenStandardInput(8192))); // This will allow input >256 chars
        while (Console.In.Peek() != -1)
        {
            string input = Console.In.ReadLine();
            Console.WriteLine("Data read was " + input);
        }
    }
