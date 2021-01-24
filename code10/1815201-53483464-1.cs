    static void Main(string[] args)
    {
        string test = GetCapitalizedInput();
        Console.WriteLine("Captured: " + test);
        Console.ReadLine();
    }
    static string GetCapitalizedInput()
    {
        string input = "";
        while (true)
        {
            var keypress = Console.ReadKey(true); // suppress original output
            if (keypress.Key == ConsoleKey.Enter)
            {
                break;
            }
            string uppercased = keypress.KeyChar.ToString().ToUpper();
            input += uppercased;
            Console.Write(uppercased);
        }
        return input;
    }
