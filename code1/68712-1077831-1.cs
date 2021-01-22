    static void Main(string[] args)
    {
        string input = Console.ReadLine();
    
        while (input != "Q")
        {
            string output;
            if (MyRegEx.TryGetStringAfterABC(input, out output))
                Console.WriteLine("Output: " + output);
            else
                Console.WriteLine("No match");
            input = Console.ReadLine();
        }
    }
