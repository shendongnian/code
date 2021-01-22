    static void Main(string[] args)
    {
        while (Console.In.Peek() != -1)
        {
            string input = Console.In.ReadLine();
            Console.WriteLine("Data read was " + input);
        }
    }
