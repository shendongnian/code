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
            var keypress = Console.ReadKey();
            if (keypress.Key == ConsoleKey.Enter)
            {
                break;
            }
            string uppercased = keypress.KeyChar.ToString().ToUpper();
            input += uppercased;
            Console.Write('\b');//backspace
            Console.Write(uppercased);
        }
        return input;
    }
